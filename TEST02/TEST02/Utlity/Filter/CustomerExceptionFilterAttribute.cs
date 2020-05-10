using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TEST02.Utlity.Filter
{
    public class CustomerExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ILogger<CustomerExceptionFilterAttribute> _logger;
        public CustomerExceptionFilterAttribute(ILogger<CustomerExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"{context.HttpContext.Request.Path}{context.Exception.Message}");
                _logger.LogError($"系统错误：{context.HttpContext.Request.Path}{context.Exception.Message}");
                context.Result = new JsonResult(new
                {
                    result = false,
                    Msg = "发生异常,请联系管理员"
                });
                context.ExceptionHandled = true;
            }
        }
    }
}
