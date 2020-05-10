using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IServersCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TEST02.Models;
using TEST02.Utlity.Filter;

namespace TEST02.Controllers
{
    [CUstomerFilterFactoryAttribute(typeof(CustomerExceptionFilterAttribute))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMessageBase _messageBase;

        public HomeController(ILogger<HomeController> logger, IMessageBase messageBase)
        {
            _logger = logger;
            _messageBase = messageBase;
        }

        public IActionResult Index()
        {
            int i = 5;
            int j = 6;
            int k = j - j;
            _messageBase.SendMessage();
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
