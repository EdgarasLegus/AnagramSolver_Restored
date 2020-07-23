using AnagramSolver.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using AnagramSolver;
using AnagramSolver.Interfaces;

namespace AnagramSolver.BusinessLogic
{


    public class AnagramSolver : Interfaces.IAnagramSolver
    {
        const string path = @"./zodynas.txt";

        public IWordRepository FRepository { get; set; }

        // Metodas - žodžio sortinimas pagal abeceles tvarka

        public static string SortByAlphabet(string inputWord)
        {
            char[] convertedToChar = inputWord.ToCharArray();
            Array.Sort(convertedToChar);

            return new string(convertedToChar);
        }

        // 222222 ----------------------
        public static Dictionary<string, string> MakeDictionary(Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            List<string> firstColumn = dictionary.Keys.ToList();

            string sortedPart;
            List<string> sortedWords = new List<string>();
            for (int i = 0; i < firstColumn.Count; i++)
            {

                sortedPart = SortByAlphabet(firstColumn[i]);
                sortedWords.Add(sortedPart);
            }

            //Žodyno sudarymas

            Dictionary<string, string> myDictionary = new Dictionary<string, string>();


            for (int i = 0; i < firstColumn.Count; i++)
            {
                if (myDictionary.ContainsKey(firstColumn[i]))
                {
                    myDictionary[firstColumn[i]] = sortedWords[i];
                }
                else
                {
                    myDictionary.Add(firstColumn[i], sortedWords[i]);
                }
            }
            return myDictionary;
        }

        public IList<string> GetAnagrams(string myWords)
        {
            // 1 - Failo pirmieji 2 stulpeliai
            Dictionary<string, string> fileColumns = FRepository.GetWords();

            // 2 - Sudarytas žodynas
            Dictionary<string, string> createdDictionary = MakeDictionary(fileColumns);
            var convertedDictionary = createdDictionary.ToList();

            // 3 - Išrušiuotas įvesties žodis
            var mySortedInputWord = SortByAlphabet(myWords);

            // 4 - Anagramų sudarymas
            var anagrams = convertedDictionary.Where(kvp => kvp.Value.Equals(mySortedInputWord)).Select(kvp => kvp.Key);


            IList<string> myList = anagrams.ToList();
            return myList;
        }

    }


}
