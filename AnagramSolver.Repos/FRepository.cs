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
