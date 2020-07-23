using AnagramSolver.BusinessLogic;
using AnagramSolver;
using AnagramSolver.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using AnagramSolver.Interfaces;

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

            Console.WriteLine("Input your word for solution: ");
            var input = Console.ReadLine();

            var anagrams = (List<string>)AnagramSolver.GetAnagrams(input);

            Console.WriteLine("Annagramos:");
            Console.WriteLine(string.Join('\n', anagrams));

        }
    }
}
