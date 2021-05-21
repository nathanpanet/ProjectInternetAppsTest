using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInternetAppsTest.Models
{
    public enum UserType
    {
        Admin,
        User,
        Supplier
    }
    public class User
    {
        public int ID { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "You must enter a user name")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "You must enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        public UserType Type { get; set; } = UserType.User;
        
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
