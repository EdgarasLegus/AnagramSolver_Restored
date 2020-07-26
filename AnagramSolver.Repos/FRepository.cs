using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace AnagramSolver.Repos
{
    public class FRepository : AnagramSolver.Interfaces.IWordRepository
    {
        // Isnesame configuration is metodo ribu, kad galima butu keisti

        //private readonly IConfigurationRoot _configuration = new ConfigurationBuilder().AddJsonFile(@"./appsettings.json").Build();
        public IConfigurationRoot _configuration;

        public FRepository()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
               .Build();
        }

        //const string path = @"./zodynas.txt";
        // ---- 1111111 Pirmojo ir antrojo stulpelio gavimas is failo
        public Dictionary<string, string> GetWords()
        {

            //_configuration = new ConfigurationBuilder()
            //  .AddJsonFile(@"./appsettings.json")
            //  .Build();

            var path = _configuration["Settings:FileName"];
            // = _configuration["Settings:FileName"];

            if (!File.Exists(path))
            {
                throw new Exception($"Data file {path} does not exist!");
            }

            // Dictionary inicializacija

            var dictionary = new Dictionary<string, string>();
            // Failo skaitymas
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string word = line.Split('\t').First();
                    string PartOfSpeech = line.Split('\t').ElementAt(1);

                    if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, PartOfSpeech);
                        //Console.WriteLine(dictionary);
                    }
                }
;
            }
            return dictionary;
        }
    }
}
