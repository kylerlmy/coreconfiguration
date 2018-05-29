using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionsBindConfig
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Class>(Configuration);  //将Class类注册一下，IOptions的方法，就可以读到和Configuration关联的配置

            services.AddMvc();   //1.将MVC加入进来，这个是依赖注入的配置
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();   //2.使用默认路由。 使用1和2两步操作，将MVC的middleware添加到应用程序当中了
            //MVC项目，需要将一下代码注释，不然会将管道抵消掉
            //app.Run(async (context) =>         //
            //{
           //使用依赖注入，通过Bind的方法，进行配置映射
            //    var myClass = new Class();
            //    Configuration.Bind(myClass);    //将appsettings.json文件中的内容与Class类进行映射

            //    await context.Response.WriteAsync($"ClassNo:{myClass.ClassNo}");
            //    await context.Response.WriteAsync($"ClassDesc:{myClass.ClassDesc}");
            //    await context.Response.WriteAsync($"{myClass.Students.Count} Students");

            //    //await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
