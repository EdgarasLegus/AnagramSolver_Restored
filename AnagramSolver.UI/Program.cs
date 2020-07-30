using AnagramSolver.BusinessLogic;
using System;
using System.Collections.Generic;
using AnagramSolver.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using AnagramSolver.Contracts;

namespace AnagramSolver.UI
{
    class Program
    {
        private static readonly IAnagramSolver _anagramSolver = new BusinessLogic.AnagramSolver();
        private static readonly IUI _userInterface = new UI();

        static void Main(string[] args)
        {

            // Konfiguracijos is json failo priskyrimas
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile(@"./appsettings.json")
             //   .Build();

            //var minInputWordLength = Int32.Parse(configuration["Settings:minInputWordLength"]);

            var minInputWordLength =  Configuration.BuilderConfigurations();

            //var minInputWordLength = ConfigurationConstants.MinInputWordLength;

            var input = _userInterface.GetUserInput(minInputWordLength);

            //// Ivesties skaitymas
            //Console.WriteLine("Input your word for solution: ");
            //var input = Console.ReadLine();

            ////// Ivesties characters skaiciavimas
            //int charCount = _anagramSolver.CountChars(input);

            ////// 1-os konfiguracijos tikrinimas
            //while (charCount < minInputWordLength)
            //{
            //    Console.WriteLine("--Chars counted: " + charCount);
            //    Console.WriteLine($"Length of input word is less than {minInputWordLength}! Try again");
            //    input = Console.ReadLine();

            //    var inputCharCount = _anagramSolver.CountChars(input);

            //    if (inputCharCount >= 1)
            //    {
            //        charCount = inputCharCount;
            //        Console.WriteLine("Input is Valid!");
            //    }
            //}

            //Console.WriteLine("--Chars counted: " + charCount);

            // konvertuoti nereikia  _
            //var anagrams = (List<string>)AnagramSolver.GetAnagrams(input);


            // Pratrint pirma
            //string anagramsForCheck = string.Join(",", anagrams.ToArray());
            //CheckAnagramCount(anagramsForCheck);

            var anagrams = _anagramSolver.GetAnagrams(input);

            //try
            //{
            //    Configurations.AnagramValidator((IList<string>)anagrams);
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("Maximum number of anagrams can be 10");
            //}

            //catch (Exception)
            //{
            //    Console.WriteLine("Unknown error");
            //}

            Console.WriteLine("---Anagramos:");
            Console.WriteLine(string.Join('\n', anagrams));


            //+++ Configuration klase , o metodas AnagramValidator, sukurt objekta pries tai.
            // Ideti validavima i try catch catch --> Console.. ArgumentException 
            // TESTAS 
            // AnagramSolver pro testus 
        }
    }
}
