using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPro.Models
{
    public class Club
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string introduction { get; set; }
        public ICollection<Person> people { get; set; }
    }
    public class ClubDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
