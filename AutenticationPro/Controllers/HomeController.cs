using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutenticationPro.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace AutenticationPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"姓名"),
                new Claim(ClaimTypes.NameIdentifier,"身份证号")
            };
            var identity = new ClaimsIdentity(claims,"authentic");
            var person = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("cookies",person);
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
    }
}
