using AnagramSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.UI
{
    public class UI : IUI
    {
        private static readonly IAnagramSolver _anagramSolver = new BusinessLogic.AnagramSolver();
        public string GetUserInput(int minInputWordLength)
        {
            // Ivesties skaitymas
            Console.WriteLine("Input your word for solution: ");
            var input = Console.ReadLine();

            // Ivesties characters skaiciavimas
            int charCount = _anagramSolver.CountChars(input);

            // 1-os konfiguracijos tikrinimas
            while (charCount < minInputWordLength)
            {
                Console.WriteLine("--Chars counted: " + charCount);
                Console.WriteLine($"Length of input word is less than {minInputWordLength}! Try again");
                input = Console.ReadLine();

                var inputCharCount = _anagramSolver.CountChars(input);

                if (inputCharCount >= 1)
                {
                    charCount = inputCharCount;
                    Console.WriteLine("Input is Valid!");
                }
            }

            Console.WriteLine("--Chars counted: " + charCount);
            return input;
        }
    }
}
