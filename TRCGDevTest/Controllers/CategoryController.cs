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


namespace TRCGDevTest.Controllers {
    [Route("api/[controller]")]
    public class CategoryController : Controller {

        private IConfigurationRoot config { get; set; }

        public CategoryController(IConfigurationRoot config) {
            this.config = config;
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get() {
            using(SQLiteConnection conn = new SQLiteConnection(config.GetConnectionString("Sqlite"))) {
                var categories = conn.Query<Category>("select categoryID, description from category");
                return categories;
            }
        }
    }
}
