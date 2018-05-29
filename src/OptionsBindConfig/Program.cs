using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OptionsBindConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //MVC项目，会使用 WebHost.CreateDefaultBuilder()  ，为我们实现创建ConfigurationBuilder对象，并调用该对象的Build方法的过程 ，默认也实现了配置的热更新
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //默认会将appsettings.json的内容添加到配置文件中
            .ConfigureAppConfiguration(builder => { builder.AddJsonFile("appsettings.json", false, false); })  //覆盖MVC的默认配置   ，将第三个参数设置成false ，就不能再时间MVC默认支持的配置热更新
                .UseStartup<Startup>()
                .Build();
    }


  



}
