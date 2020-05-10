using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TEST02.Utlity.Filter;
using static TEST02.Startup;

namespace TEST02.Controllers
{
    [ServiceFilter(typeof(CustomerExceptionFilterAttribute))]
    [CustomControllerFilterAttribute]
    public class fifthController : Controller
    {
         
        [CustomActionFilterAttribute]
        public IActionResult Index()
        { 
            int i = 5;
            int j = 6;
            int k = j - j;
            //int m = i / k;
            Console.WriteLine("业务代码");
            return View();
        }
        public IActionResult Info()
        {


            int i = 5;
            int j = 6;
            int k = j - j;
            int m = i / k;
            return View();
        }
    }
}