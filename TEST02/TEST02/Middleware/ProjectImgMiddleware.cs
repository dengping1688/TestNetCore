using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST02.Middleware
{
    public class ProjectImgMiddleware
    {
        private readonly IHostingEnvironment _env;
        readonly RequestDelegate _next;
        public ProjectImgMiddleware(RequestDelegate next,IHostingEnvironment env)
        {
            _env = env;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILogger<ProjectImgMiddleware> logger)
        {
            //return Task.CompletedTask;
            bool allowEmptyReffer = false;
            string[] imgTypes = new string[] { "jpg", "png", "ico" };
            string oriUrl = $"{context.Request.Scheme}://{context.Request.Host.Value}".ToLower();
            var reffer = context.Request.Headers[HeaderNames.Referer].ToString().ToLower();
            reffer = string.IsNullOrEmpty(reffer) ? context.Request.Headers["Refferer"].ToString().ToLower() : reffer;
            //请求资源后缀
            string pix = context.Request.Path.Value.Split(".").Last();
            if (imgTypes.Contains(pix) && !reffer.StartsWith(oriUrl) && (string.IsNullOrEmpty(reffer) && !allowEmptyReffer))
            {
                logger.LogDebug($"来自{reffer}的异常访问");
                //不是本站请求返回特定图片  
                context.Response.SendFileAsync(Path.Combine(_env.WebRootPath, "404.jfif")).Wait();

                 await Task.CompletedTask;
            }
             await  _next(context);
        }
    }
}
