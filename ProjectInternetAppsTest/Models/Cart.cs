using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public Order Order { get; set; }
        public User User { get; set; }
    }
}
