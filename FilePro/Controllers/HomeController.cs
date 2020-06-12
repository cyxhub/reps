using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilePro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace FilePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
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
        ////
        ///文件上传
        ///
        public async Task<IActionResult> filesave(List<IFormFile> files)
        {
            var f = Request.Form.Files;
            long size = files.Sum(f=>f.Length);
            string webrootpath = _webHostEnvironment.WebRootPath;
            foreach(var file in files)
            {
                if (file.Length > 0)
                {
                    string fileExt = Path.GetExtension(file.FileName);
                    long filesize = file.Length;
                    string newfilename = System.Guid.NewGuid().ToString() + fileExt;
                    var filepath = webrootpath + "\\upload\\" + newfilename;
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {

                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count=files.Count,filesize = size });
        }
        /// <summary>
        /// 文件流的方式输出        
        /// <returns></returns>
        public IActionResult DownLoad(string file)
        {
            var stream = System.IO.File.OpenRead("D:\\upload\\" + file);
            string fileExt = Path.GetExtension(file);
            //获取文件的ContentType
            var provider = new FileExtensionContentTypeProvider();
            var memi = provider.Mappings[fileExt];
            return File(stream, memi, Path.GetFileName(file));
        }
    }
}
