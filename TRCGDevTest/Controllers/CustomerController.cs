using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using TRCGDevTest.Models;
using System.Data.SQLite;


namespace TRCGDevTest.Controllers.Api {

    [Route("api/[controller]")]
    public class CustomerController : Controller {
        private IConfigurationRoot config { get; set; }

        public CustomerController(IConfigurationRoot config) {
            this.config = config;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get() {
            using(SQLiteConnection conn = new SQLiteConnection(config.GetConnectionString("Sqlite"))) {
                var customers = conn.Query<Customer>("select customer.customerID, customer.firstName, customer.lastName, category.description from customer inner join category on category.categoryID = customer.categoryID");
                return customers;
            }
        }
        
        // POST: api/Customer
        [HttpPost]
        public IEnumerable<Customer> Post([FromBody]Customer value) {
            using(SQLiteConnection conn = new SQLiteConnection(config.GetConnectionString("Sqlite"))) {
                var query = "update customer set firstName = @firstName, lastName = @lastName, categoryID = @categoryID where customerID = @customerID";
                conn.Query(query, value);

                return Get();
            }
        }     
    }
}
