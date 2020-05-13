using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loggingtest.Controllers
{
    public class ValuesController:Controller
    {
        private ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }
        public ActionResult get()
        {
            _logger.LogWarning("打印infomatino");
            return Json("info");
        }
    }
}
