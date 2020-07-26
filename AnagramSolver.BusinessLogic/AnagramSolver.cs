using System;
using System.Collections.Generic;
using System.Linq;
using AnagramSolver.Interfaces;
using AnagramSolver.Repos;

namespace AnagramSolver.BusinessLogic
{
    public class AnagramSolver : Interfaces.IAnagramSolver
    {
        // TESTAS 
        // ++++ ISKELTI I JSON 
        // TESTAMS KITAS JSONAS
        // ar gerai nuskaitomas failas
        // where select 
        // ASP .NET MVC - kita tema

        private Dictionary<string, string> _createdDictionary;


        public IWordRepository FRepository { get; set; }

        public AnagramSolver()
        {
            var repository = new FRepository();
            // 1 zingsnis --- Gauname failo pirmuosius 2 stulpelius
            var fileColumns = repository.GetWords();

            // 2 zingsnis -- Zodyno sudarymas
            _createdDictionary = MakeDictionary(fileColumns);
        }

    //BUVO public IList<string> GetAnagrams(string myWords)
    public IEnumerable<string> GetAnagrams(string myWords)
        {

            //
            // 1 - Failo pirmieji 2 stulpeliai
            // -----VAR
            // Kiekviena karta ne kolint idet 
            //Dictionary<string, string> fileColumns = FRepository.GetWords();

            // 2 - Sudarytas žodynas
            //Dictionary<string, string> createdDictionary = MakeDictionary(fileColumns);

            // NEREIKES EILUTES
            //var convertedDictionary = createdDictionary.ToList();

            // 3 - Išrušiuotas įvesties žodis
            var mySortedInputWord = SortByAlphabet(myWords);

            // 4 - Anagramų sudarymas
            var anagrams = _createdDictionary
                .Where(kvp => kvp.Value.Equals(mySortedInputWord))
                .Select(kvp => kvp.Key);


            //ISIMTA ---- IList<string> myList = anagrams.ToList();
            return anagrams;
        }

        //private Dictionary<string, string> dictionary;
        // private IWordRepository _repository; -- nereikia

        //public AnagramSolver()
        //{
        //   var temp = FRepository.GetWords();
        //MakeDictionary
        //   // new FRepository
        //}

        // CIA GET WORDS
        // 3,4 

        // Metodas - žodžio sortinimas pagal abeceles tvarka
        public string SortByAlphabet(string inputWord)
        {
            char[] convertedToChar = inputWord.ToCharArray();
            Array.Sort(convertedToChar);

            return new string(convertedToChar);
        }

        // 222222 ----------------------
        // STATIC VENGTI 
        private Dictionary<string, string> MakeDictionary(Dictionary<string, string> dictionary)
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

        // KINTAMUJU PAVADINIMAS
        // IEnumerable 

        //BUVO public static int
        public int CountChars(string input)
        {
            // Pavertimas i char lista
            // GALIM PRATRINT, TIK RETURN
            List<char> charlist = new List<char>();
            charlist.AddRange(input);

            // CharListo characteriu skaiciavimas
            char[] characters = input.ToCharArray();
            int charCount = input.Count(c => !Char.IsWhiteSpace(c));

            return charCount;
        }

    }


}
