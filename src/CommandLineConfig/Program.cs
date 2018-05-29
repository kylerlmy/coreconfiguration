using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommandLineConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = new Dictionary<string, string>() {{"name", "kyle"}, {"age", "18"}};

          var builder=new ConfigurationBuilder();
            builder.AddInMemoryCollection(setting);
            builder.AddCommandLine(args);
            var configuration = builder.Build();
            Console.WriteLine($"name:{configuration["name"]}");
            Console.WriteLine($"age:{configuration["age"]}");
            Console.ReadLine();

        }
    }
}
