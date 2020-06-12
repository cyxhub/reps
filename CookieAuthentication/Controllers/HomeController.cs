using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CookieAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CookieAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //--------------------------------
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string username,string userpassword)
        {
            var user=UserLocal.userlist.First(x=>x.name==username&&x.password==userpassword);
            if (user != null)
            {
                var userClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.name),
                    new Claim("age",$"{user.age}")
                };
                var personIdentity = new ClaimsIdentity(userClaim, "identitycard");
                var principle = new ClaimsPrincipal(new[] { personIdentity });
                HttpContext.SignInAsync(principle);
                return Redirect("/home/resource");
            }
            return View("index");
        }
        [Authorize]
        public IActionResult resource()
        {
            ViewBag.cok = HttpContext.Request.Cookies["accountname"];
            return View();
        }
    }
}
