using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public class SaleDiscount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }
        public double Discount { get; set; } // should be in percentage
        //public Product Product { get; set; }
        public string Description { get; set; }
    }
}
