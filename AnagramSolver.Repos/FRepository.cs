using AnagramSolver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramSolver.Repos
{
    public class FRepository : AnagramSolver.Interfaces.IWordRepository
    {
        const string path = @"./zodynas.txt";
        // Zodziu rodymas 
        //        public List<Contracts.Anagram> GetWords()
        //        {

        //            // Dictionary inicializacija
        //            var dictionary = new Dictionary<string, string>();
        //            List<string> sortedWords = new List<string>();

        //            // Failo skaitymas
        //            using (StreamReader reader = new StreamReader(path))
        //            {
        //                string line;
        //                while ((line = reader.ReadLine()) != null)
        //                {
        //                    string word = line.Split('\t').First();
        //                    string PartOfSpeech = line.Split('\t').ElementAt(1);

        //                    if (!dictionary.ContainsKey(word))
        //                    {
        //                        dictionary.Add(word, PartOfSpeech);
        //                    }
        //                }
        //;
        //            }
        //            List<Contracts.Anagram> myList = new List<Contracts.Anagram>();

        //            foreach (var keyValuePair in dictionary)
        //            {
        //                //Console.WriteLine(keyValuePair.Key);
        //                //Console.WriteLine(keyValuePair.Value);
        //                myList.Add(new Contracts.Anagram { Word = keyValuePair.Key, PartOfSpeech = keyValuePair.Value });
        //            }
        //            var pattern = string.Join(",", myList.Select(cff => cff.ToString()));
        //            Console.WriteLine(pattern);

        //            return myList;
        //        }


        // ---- 1111111 Pirmojo ir antrojo stulpelio gavimas is failo
        public Dictionary<string, string> GetWords()
        {

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
