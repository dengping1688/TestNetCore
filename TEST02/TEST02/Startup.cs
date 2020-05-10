using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using IServersCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using ServersCore;
using TEST02.Extensions;
using TEST02.Middleware;
using TEST02.Utlity.Filter;

namespace TEST02
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
           {
               //option.Filters.Add(typeof(CustomerExceptionFilterAttribute));
               option.Filters.Add(typeof(CustomGlobelFilterAttribute)); 
           });
            //services.AddSingleton<ProjectImgMiddleware>();
            services.AddSession();
            services.AddTransient<ITestServicesA,TestServiceA>();
            services.AddTransient<ITestServicesB, TestServiceB>();
            services.AddTransient<ITestServicesC, TestServiceC>();
            services.AddTransient<ITestServicesD, TestServiceD>();
            services.AddTransient<CustomerExceptionFilterAttribute>();
            services.AddMessage( option => {
                option.UserSms();
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterModule<CustomAutofacModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            #region MiddleWare1
            //app.Use(next =>
            //{
            //    Console.WriteLine(" MiddleWare1 Out");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is MiddleWare1 Start\r\n");
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("This is MiddleWare1 end\r\n");
            //        });
            //});

            //app.Use(next =>
            //{
            //    Console.WriteLine(" MiddleWare2 Out");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is MiddleWare2 Start\r\n");
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("This is MiddleWare2 end\r\n");
            //        });
            //});
            //app.Use(next =>
            //{
            //    Console.WriteLine(" MiddleWare3 Out");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is MiddleWare3 Start\r\n");
            //            //await next.Invoke(context);
            //            await context.Response.WriteAsync("This is MiddleWare3 end\r\n");
            //        });
            //});
            #endregion
            //app.Use(next =>
            //{
            //    return async c => { await c.Response.WriteAsync("Hello,CloudOver\r\n"); };
            //});

            app.Use(async (context,next)=>{
                await context.Response.WriteAsync("Hello,Middle 1 Begin \r\n");
                await next();
                await context.Response.WriteAsync("Hello,Middle 1 end \r\n");
            });
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("Hello,Middle 2 Begin \r\n");
                await next();
                await context.Response.WriteAsync("Hello,Middle 2 end \r\n");
            });
            app.UseProjectImg();
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("Hello,Middle 3 Begin \r\n");
                 //context.Response.OnCompleted(next);
                await next();
                await context.Response.WriteAsync("Hello,Middle 3 end \r\n");
            });
            app.Run( async context=> 
            {
               await context.Response.WriteAsync("Hello,Run   \r\n");
            });
            //app.UseProjectImg();
            //app.UseSession();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            //});

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }

        public class CustomAutoFacAop : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                Console.WriteLine($"invocation.Method={invocation.Method}");
                Console.WriteLine($"invocation.Arguments={string.Join(",",invocation.Arguments)}");
                invocation.Proceed();
                Console.WriteLine($"invocation.Method={invocation.Method}执行完成了");
            }
        }
        public interface IA
        {
            void Show(int id, string name);

        }
        [Intercept(typeof(CustomAutoFacAop))]
        public class A : IA
        {
            public void Show(int id, string name)
            {
                Console.WriteLine($"This is A{id}_{name}");
            }
        }
    }
}
