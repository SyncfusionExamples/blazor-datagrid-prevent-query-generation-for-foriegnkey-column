using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODataV4Service.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.OData.Routing;

namespace ODataV4Service.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ODataController
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Customers.Count() == 0)
            {
                _db.AddRange(Startup.Customers);
            }
            _db.SaveChanges();
            if (context.Books.Count() == 0)
            {
                _db.AddRange(Startup.Books);
            }
            _db.SaveChanges();
        }
        // GET api/values
        [HttpGet]
        [ODataRoute]
        public PageResult<Book> Get(ODataQueryOptions opts)
        {
            var results = _db.Books.AsQueryable();
            var count = results.Count();
            if (opts.OrderBy != null)
                results = opts.OrderBy.ApplyTo(results);
            if (opts.Filter != null)
            {
                results = opts.Filter.ApplyTo(results, new ODataQuerySettings()).Cast<Book>();
            }
            var queryString = opts.Request.Query;
            string search = queryString["$search"];
            if (search != null)
            {
                //sarch query is maintained. to overcome that we have used below workaround
                string key = search.Split(" OR ")[search.Split(" OR ").Length - 1];
                //searched the typed string using where query and retured the results.
                results = results.Where(fil => fil.Id.ToString().ToLower().Contains(key) || fil.Name.ToLower().Contains(key) || fil.Gender.ToString().ToLower().Contains(key) || fil.Active.ToString().ToLower().Contains(key) || fil.CreditLimit.ToString().ToLower().Contains(key) || fil.RegistrationDate.ToString().ToLower().Contains(key));
            }
            if (opts.Count != null)
                count = results.Count();
            if (opts.Skip != null)
                results = opts.Skip.ApplyTo(results, new ODataQuerySettings());
            if (opts.Top != null)
                results = opts.Top.ApplyTo(results, new ODataQuerySettings());
            return new PageResult<Book>(results, null, count);
        }

        public async Task<IActionResult> Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Created(book);
        }

        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<Book> book)
        {
            var entity = await _db.Books.FindAsync(key);
            book.Patch(entity);
            await _db.SaveChangesAsync();
            return Updated(entity);
        }

        // PUT api/values/"5"

        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Book book)
        {
            var entity = await _db.Books.FindAsync(book.Id);
            _db.Entry(entity).CurrentValues.SetValues(book);
            await _db.SaveChangesAsync();
            return Updated(book);
        }

        // DELETE api/values/5
        public int Delete([FromODataUri] int key)
        {
            var od = _db.Books.Find(key);

            _db.Books.Remove(od);
            _db.SaveChanges();
            return key;
            //return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
