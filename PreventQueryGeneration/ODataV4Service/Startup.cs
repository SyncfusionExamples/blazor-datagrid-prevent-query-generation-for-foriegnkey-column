using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using ODataV4Service.Models;

namespace ODataV4Service
{
    public class Startup
    {
        public static List<Customer> Customers { get; set; }
        public static List<Book> Books { get; set; }


        #region Static Initializers
        static Startup()
        {
            #region Customers seed list
            Customers = Enumerable.Range(1, 1000).Select(index => new Customer()
            {
                Id = Guid.NewGuid(),
                Name = $"Customer-{index}"
            }).ToList();
            #endregion
            Books = Enumerable.Range(1, 100).Select(index => new Book()
            {
                Active = true,
                //CreditLimit = (int)(new Random().NextDouble() * 10000),
                CreditLimit = (int) index * 1,
                CustomerId = Customers[new Random().Next(0, Customers.Count)].Id,
                CustomerId1 = Customers[new Random().Next(0, Customers.Count)].Id,
                Id = Guid.NewGuid(),
                IsDeleted = false
            }).ToList();
            #endregion
        }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var books = builder.EntitySet<Book>("Books");
            var customers = builder.EntitySet<Customer>("Customers");
            FunctionConfiguration myFirstFunction = books.EntityType.Collection.Function("MyFirstFunction");
            myFirstFunction.ReturnsCollectionFromEntitySet<Book>("Books");
            return builder.GetEdmModel();
        }

        public IConfiguration Configuration { get; }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
            services.AddOData();      
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                ODataBatchHandler odataBatchHandler =
      new DefaultODataBatchHandler();
                routes.MapODataServiceRoute(
                 "odata",
                 "odata",
                 model: GetEdmModel(),
                 batchHandler: odataBatchHandler
               );
            });
        }
    }
}
