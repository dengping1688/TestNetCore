using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST02.Utlity.Filter
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("this is CustomActionFilterAttribute OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("this is CustomActionFilterAttribute OnActionExecuting");
        }
    }
    public class CustomControllerFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("this is CustomControllerFilterAttribute OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("this is CustomControllerFilterAttribute OnActionExecuting");
        }
    }
    public class CustomGlobelFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("this is CustomGlobelFilterAttribute OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("this is CustomGlobelFilterAttribute OnActionExecuting");
        }
    }
}
