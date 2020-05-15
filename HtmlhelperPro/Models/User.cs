using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlhelperPro.Models
{
    public class User
    {
        public int id { get; set; }
        [Display(Name ="姓名")]
        public string name { get; set; }
    }
}
