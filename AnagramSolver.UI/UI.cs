using AnagramSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.UI
{
    public class UI : IUI
    {
        private static readonly IAnagramSolver _anagramSolver = new BusinessLogic.AnagramSolver();
        private static readonly HttpClient client = new HttpClient();

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

        public async Task<string> RequestAPI(string inputForRequest)
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44325/api/" + inputForRequest);
            responseMessage.EnsureSuccessStatusCode();

            var responseBody = await responseMessage.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
