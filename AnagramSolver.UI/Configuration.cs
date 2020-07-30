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

            return minInputWordLength;
        }
    }
}
