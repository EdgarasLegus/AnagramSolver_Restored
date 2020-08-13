using AnagramSolver.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
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

        public static string GetFileNameFromConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var FileName = configuration["Settings:FileName"];

            return FileName;
        }

        public static string GetConnectionStringDBFirst()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var connectionString = configuration["ConnectionProperties:ConnectionStringDBFirst"];
            return connectionString;
        }

        public static string GetConnectionStringCodeFirst()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var connectionString = configuration["ConnectionProperties:ConnectionStringCodeFirst"];
            return connectionString;
        }
    }
}
