using AnagramSolver.Contracts;
using System;
using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IAnagramSolver
    {
        // Padaryta - IList pakeista i IEnumerable 
        //IList<string> GetAnagrams(string myWords);
        //PRidet CountChars
        IEnumerable<string> GetAnagrams(string myWords);
        int CountChars(string input);
        string SortByAlphabet(string inputWord);
        //Dictionary<string, string> MakeDictionary(Dictionary<string, string> dictionary);
        Dictionary<string, string> MakeDictionary(List<WordModel> wordModel);
    }
}
