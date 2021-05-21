using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        //anotation needed - short string
        public string ShortDescription { get; set; } //for catgory page - we dont want to see there all the info
        //Migration is needed
        
        public byte[] Img { get; set; }
        public Category Category { get; set; }
        public SaleDiscount Discount { get; set; }
        public List<Order> Orders { get; set; } //shoudnt be here but without this its makeing a one to many....
    }
}
