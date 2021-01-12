using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRCGDevTest.Models {

    public class Customer {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int? categoryID { get; set; }
        public string description { get; set; }
    }

    public class Category {
        public int categoryID { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }

}
