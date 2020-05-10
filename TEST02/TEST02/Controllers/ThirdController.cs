using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServersCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TEST02.Controllers
{
    public class ThirdController : Controller
    {
        private readonly ILogger<ThirdController> _logger;
        public readonly ITestServicesA _testServicesA;
        public readonly ITestServicesD _testServicesD;
        public ThirdController(ILogger<ThirdController> logger, 
            ITestServicesA testServicesA,
            ITestServicesD testServicesD)
        {
            _logger = logger;
            _testServicesA = testServicesA;
            _testServicesD = testServicesD;
        }
        public IActionResult Index()
        {
            _testServicesA.Show();
            _testServicesD.Show();
            _logger.LogWarning("this is Third Index");
            return View();
        }
    }
}