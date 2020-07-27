using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Contracts
{
    public class ConfigurationConstants
    {

        public static int MaxNumberOfAnagrams { get; set; }
        public static int MinInputWordLength { get; set; }
        public static int MinNumberOfAnagrams { get; set; }
        public static string FileName { get; set; }

        public static IConfigurationRoot ConfBuilder { get; set; }

        //public ConfigurationConstants()
        //{
        //    ConfBuilder = new ConfigurationBuilder()
         //   .AddJsonFile(@"./appsettings.json")
          //  .Build();
           // FileName = ConfBuilder["Settings:FileName"];
        //}

    }
}
