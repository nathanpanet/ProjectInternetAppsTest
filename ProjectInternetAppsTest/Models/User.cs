using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public enum UserType
    {
        Admin,
        User
    }
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; } = UserType.User;
        public string Address { get; set; }
        public string Phone { get; set; }
        //public Cart Cart { get; set; } = null;
    }
}
