using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.UI
{
    public class Configuration
    {
        public static int BuilderConfigurations()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var minInputWordLength = Int32.Parse(configuration["Settings:minInputWordLength"]);
            var FileName = configuration["Settings:FileName"];

            return minInputWordLength;
        }

        public static string GetFileNameFromConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var FileName = configuration["Settings:FileName"];

            return FileName;
        }
    }
}
