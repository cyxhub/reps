using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutePro.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult List()
        {
            return Json("list");
        }
    }
}
