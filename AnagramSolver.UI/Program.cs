using AnagramSolver.BusinessLogic;
using AnagramSolver;
using AnagramSolver.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using AnagramSolver.Interfaces;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace AnagramSolver.UI
{
    class Program
    {
        static readonly IAnagramSolver AnagramSolver = new BusinessLogic.AnagramSolver()
        {
            FRepository = new FRepository()
        };

        static void Main(string[] args)
        {
            // Konfiguracijos, skaiciaus istraukimas
            var configuration = new ConfigurationBuilder().AddJsonFile(@"./appsettings.json").Build();
            var firstConfig = configuration["Settings:minInputWordLength"];
            var firstConfigAsInt = Int32.Parse(firstConfig);


            // Ivesties skaitymas
            Console.WriteLine("Input your word for solution: ");
            var input = Console.ReadLine();

            //var inputLine = input.Split(' ').ToList();

            // Ivesties characters skaiciavimas
            int charCount = BusinessLogic.AnagramSolver.CountChars(input);

            // 1-os konfiguracijos tikrinimas
            while (charCount < firstConfigAsInt)
            {
                Console.WriteLine("--Chars counted: " + charCount);
                Console.WriteLine($"Length of input word is less than {firstConfigAsInt}! Try again");
                input = Console.ReadLine();

                var inputCharCount = BusinessLogic.AnagramSolver.CountChars(input);
                    
                if(inputCharCount >= 1)
                {
                    charCount = inputCharCount;
                    Console.WriteLine("Input is Valid!");
                }
            }

            Console.WriteLine("--Chars counted: " + charCount);
            //CheckWordLength(input);

            var anagrams = (List<string>)AnagramSolver.GetAnagrams(input);
            
            string anagramsForCheck = string.Join(",", anagrams.ToArray());
            CheckAnagramCount(anagramsForCheck);

            Console.WriteLine("---Anagramos:");
            Console.WriteLine(string.Join('\n', anagrams));

        }


        public static void CheckAnagramCount(string anagrams)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(@"./appsettings.json").Build();

            var secondConfig = configuration["Settings:MaxNumberOfAnagrams"];
            //var thirdConfig = configuration["Settings:MinNumberOfAnagrams"];
            //Console.WriteLine("HERE: " + secondConfig);
            var secondConfigAsInt = Int32.Parse(secondConfig);
            //var thirdConfigAsInt = Int32.Parse(thirdConfig);

            var parts = anagrams.Split(' ').Length;
            if (parts > secondConfigAsInt)
            {
                throw new Exception("Maximum number of anagrams can be 10");
            }
            //else if (parts < thirdConfigAsInt)
            //{
            //    throw new Exception("Minimum number of anagrams can be 1. Your word is not present in dictionary.");
            //}
        }




    }
}
