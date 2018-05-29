using System;
using Microsoft.Extensions.Configuration;

namespace JsonConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //这里通过自己定义ConfigurationBuilder 的对象，然后通过这个对象的Build方法拿到一个IConfigurationRoot的对象
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("class.json",false,true);//第二个参数表示当这个文件不存在的话是否抛异常，第三个参数表示，在配置改变的时候，是否重新加载配置（用于实现配置的热更新）

            var confiuration = builder.Build();

            Console.WriteLine($"ClassNo:{confiuration["ClassNO"]}");
            Console.WriteLine($"ClassDesc:{confiuration["ClassDesc"]}");

            Console.WriteLine("Students");

            Console.Write(confiuration["Students:0:name"]);
            Console.WriteLine(confiuration["Students:0:age"]);
            Console.Write(confiuration["Students:1:name"]);
            Console.WriteLine(confiuration["Students:1:age"]);

            Console.ReadLine();
        }
    }
}
