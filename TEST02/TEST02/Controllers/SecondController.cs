using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TEST02.Controllers
{
    public class SecondController : Controller
    {
        private readonly ILogger<SecondController> _logger;

        public SecondController(ILogger<SecondController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogWarning("测试日志");
            return View();
        }
    }
}