using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationPro.Models
{
    public class Users
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="名称")]
        [StringLength(maximumLength:3)]
        public string name { get; set; }
        [Display(Name ="邮件")]
        //[EmailAddress(ErrorMessage ="这个是邮件")]
        public string email { get; set; }
    }
}
