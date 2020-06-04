using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAuthentication.Models
{
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        
    }
    public class UserLocal
    {
        public static IEnumerable<Users> userlist = new List<Users>
        {
            new Users{id=1,name="er",password="er", age=3},
            new Users{id=2,name="et",password="et", age=6},
        };
    }
}
