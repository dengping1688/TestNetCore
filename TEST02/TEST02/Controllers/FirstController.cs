using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TEST02.Models;

namespace TEST02.Controllers
{
    public class FirstController : Controller
    { 
         private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("dddddd");
            base.ViewData["User1"] = new CurrentUser { ID = 110, Name = "邓福平" };
            base.ViewBag.Name = "等分";
            var data = new CurrentUser { ID = 110, Name = "邓福平" };

            HttpContext.Session.GetString("current");
            return View(data);
        }
    }
}