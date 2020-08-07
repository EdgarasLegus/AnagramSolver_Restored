using System;
using System.Collections.Generic;
using System.Linq;
using AnagramSolver.Contracts;
using AnagramSolver.Interfaces;
using AnagramSolver.Repos;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramSolver : IAnagramSolver
    {
        // TESTAS 
        // ar gerai nuskaitomas failas

        private Dictionary<string, string> _createdDictionary;

        public IWordRepository FRepository { get; set; }

        public AnagramSolver()
        {
            //var repository = new FRepository();
            var repository = new DBRepository();
            // 1 zingsnis --- Gauname failo pirmuosius 2 stulpelius
            var fileColumns = repository.GetWords();

            _createdDictionary = MakeDictionary(fileColumns);
        }

    public IEnumerable<string> GetAnagrams(string myWords)
        {
            // 1 - Failo pirmieji 2 stulpeliai
            // -----VAR
            // Kiekviena karta ne kolint idet 
            //Dictionary<string, string> fileColumns = FRepository.GetWords();

            // 2 - Sudarytas žodynas
            //Dictionary<string, string> createdDictionary = MakeDictionary(fileColumns);

            // 3 - Išrušiuotas įvesties žodis
            var mySortedInputWord = SortByAlphabet(myWords);

            // 4 - Anagramų sudarymas
            var anagrams = _createdDictionary
                .Where(kvp => kvp.Value.Equals(mySortedInputWord))
                .Select(kvp => kvp.Key);

            return anagrams;
        }

        // CIA GET WORDS
        // 3,4 

        // Metodas - žodžio sortinimas pagal abeceles tvarka

        public string SortByAlphabet(string inputWord)
        {
            char[] convertedToChar = inputWord.ToCharArray();
            Array.Sort(convertedToChar);

            return new string(convertedToChar);
        }

        public Dictionary<string, string> MakeDictionary(List<WordModel> wordModel)
        {
            var wordModelDictionary = wordModel.ToDictionary(x => x.Word, x => x.Category);
            var sortedDictionary = wordModelDictionary.ToDictionary(x => x.Key, y => SortByAlphabet(y.Key));
            return sortedDictionary;
        }

        public int CountChars(string input)
        {
            // CharListo characteriu skaiciavimas
            char[] characters = input.ToCharArray();
            int charCount = input.Count(c => !Char.IsWhiteSpace(c));
            return charCount;
        }

        //222222 ----------------------
        //public Dictionary<string, string> MakeDictionary(Dictionary<string, string> dictionary)
        //{
        //    //Dictionary<string, string> data = new Dictionary<string, string>();

        //    //List<string> firstColumn = dictionary.Keys.ToList();

        //    //string sortedPart;
        //    //List<string> sortedWords = new List<string>();
        //    //for (int i = 0; i < firstColumn.Count; i++)
        //    //{

        //    //    sortedPart = SortByAlphabet(firstColumn[i]);
        //    //    sortedWords.Add(sortedPart);
        //    //}

        //    ////Žodyno sudarymas
        //    //Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        //    //for (int i = 0; i < firstColumn.Count; i++)
        //    //{
        //    //    if (myDictionary.ContainsKey(firstColumn[i]))
        //    //    {
        //    //        myDictionary[firstColumn[i]] = sortedWords[i];
        //    //    }
        //    //    else
        //    //    {
        //    //        myDictionary.Add(firstColumn[i], sortedWords[i]);
        //    //    }
        //    //}
        //    //return myDictionary;

        //    var sortedDictionary = dictionary.ToDictionary(x => x.Key, y => SortByAlphabet(y.Key));
        //    return sortedDictionary;
        //}

    }
}
