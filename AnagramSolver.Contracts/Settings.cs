using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts
{
    public class Settings
    {
        public static int MaxNumberOfAnagrams { get; set; }
        public static int MinInputWordLength { get; set; }
        public static int MinNumberOfAnagrams { get; set; }
        public static string FileName { get; set; }
        public static string ConnectionString { get; set; }

        public static string GetSettingsConnectionStringDBFirst()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var connectionString = configuration["ConnectionProperties:ConnectionStringDBFirst"];
            return connectionString;
        }

        public static string GetSettingsConnectionStringCodeFirst()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .Build();
            var connectionString = configuration["ConnectionProperties:ConnectionStringCodeFirst"];
            return connectionString;
        }

    }
}
