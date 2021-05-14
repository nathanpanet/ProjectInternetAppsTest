using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public enum OrderStatus
    {
        Cart,
        Ordered,
        Delivered
    }
    public class Order
    {
        public int ID { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime PayedOn { get; set; }
        public OrderStatus Status { get; set; }
        public List<Product> Products { get; set; }
        public User User { get; set; }
        public float TotalPrice { get; set; }
    }
}
