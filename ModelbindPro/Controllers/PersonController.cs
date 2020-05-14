using Microsoft.AspNetCore.Mvc;
using ModelbindPro.Binders;
using ModelbindPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelbindPro.Controllers
{
    public class PersonController:Controller
    {
        public IActionResult index([ModelBinder(binderType:typeof(Custombind))]string text)
        {
            return Json(text);
        }
       
    }
}
