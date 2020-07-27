using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AnagramSolver.BusinessLogic
{
    public class Configurations
    {

        //private IConfigurationRoot _configuration;

        //public Configurations()
        //{
         //   _configuration = new ConfigurationBuilder()
          //      .AddJsonFile(@"./appsettings.json")
           //     .Build();
        //}

        public void AnagramValidator(IList<string> anagrams)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile(@"./appsettings.json")
            .Build();

            //var thirdConfig = configuration["Settings:MinNumberOfAnagrams"];

            //!!!!!!!!!! TryParse 

            var MaxNumberOfAnagrams = Int32.Parse(configuration["Settings:MaxNumberOfAnagrams"]);

            if (anagrams.Count > MaxNumberOfAnagrams)
            {
                throw new Exception("Maximum number of anagrams can be 10");
            }
        }
    }
}
