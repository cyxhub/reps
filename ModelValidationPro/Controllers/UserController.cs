using Microsoft.AspNetCore.Mvc;
using ModelValidationPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationPro.Controllers
{
    public class UserController:Controller
    {
        public IActionResult very(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return Json(true);
        }
    }
}
