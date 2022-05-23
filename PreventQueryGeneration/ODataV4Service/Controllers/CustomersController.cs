using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataV4Service.Models;

namespace ODataV4Service.Controllers
{
    [Route("api/[controller]")] 
    public class CustomersController : ODataController
    {
        private BookStoreContext _db;

        public CustomersController(BookStoreContext context)
        {
            _db = context;
            if (context.Customers.Count() == 0)
            {
                _db.AddRange(Startup.Customers);
            }
            _db.SaveChanges();
        }

        private void GenerateSeed()
        {
            //var generated = Enumerable.Range(1, 500).AsParallel().Select(index => new Customer()
            //{
            //    Email = $"Customer-{index}",
            //    Gender = new Random().NextDouble() > 0.5 ? Gender.Female : Gender.Male,
            //    Id = Guid.NewGuid(),
            //    LastName = $"CustomerLastName-{index}",
            //    Name = $"CustomerName-{index}",
            //    RegistrationDate = DateTime.Now.AddDays(-1000 * new Random().NextDouble())
            //});

            //string result = string.Join(", \n", generated);
            //Debug.WriteLine("-------------------------------------------------------------------");
            //Debug.WriteLine(result);
            //Debug.WriteLine("-------------------------------------------------------------------");
        }

        // GET api/values
        [HttpGet]
        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return _db.Customers.AsQueryable();
        }

        public async Task<IActionResult> Post([FromBody] Customer Customer)
        {
            _db.Customers.Add(Customer);
            _db.SaveChanges();
            return Created(Customer);
        }

        public async Task<IActionResult> Patch([FromODataUri] Guid key, [FromBody] Delta<Customer> Customer)
        {
            var entity = await _db.Customers.FindAsync(key);
            Customer.Patch(entity);
            await _db.SaveChangesAsync();
            return Updated(entity);
        }

        // PUT api/values/"5"

        public async Task<IActionResult> Put([FromODataUri] Guid key, [FromBody] Customer Customer)
        {
            var entity = await _db.Customers.FindAsync(Customer.Id);
            _db.Entry(entity).CurrentValues.SetValues(Customer);
            await _db.SaveChangesAsync();
            return Updated(Customer);
        }

        // DELETE api/values/5
        public Guid Delete([FromODataUri] Guid key)
        {
            var od = _db.Customers.Find(key);

            _db.Customers.Remove(od);
            _db.SaveChanges();
            return key;
            //return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
