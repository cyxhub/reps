using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPro.Models
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
    }
    public class PersonDto 
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }

}
