using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST02.Middleware
{
    public static class ProjectImgMiddlewareExtensions
    {
        public static IApplicationBuilder UseProjectImg(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProjectImgMiddleware>();
        }
    } 
}
