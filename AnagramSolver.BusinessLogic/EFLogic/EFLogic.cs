using System;
using System.Collections.Generic;
using System.Text;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Contracts.Entities;
using System.Linq;
using AnagramSolver.Contracts;
using AnagramSolver.Interfaces.DBFirst;
using System.Runtime.CompilerServices;
using AnagramSolver.EF.CodeFirst;

namespace AnagramSolver.BusinessLogic
{
    public class EFLogic : IEFLogic
    {
        //private readonly AnagramSolverDBFirstContext _context;
        private readonly AnagramSolverCodeFirstContext _context;
        //public EFLogic(AnagramSolverDBFirstContext context)
        //{
        //    _context = context;
        //}

        public EFLogic(AnagramSolverCodeFirstContext context)
        {
            _context = context;
        }

        public List<WordEntity> SearchWords(string searchInput)
        {
            var wordList = _context.Word.Where(x => x.Word1.Contains(searchInput)).ToList();
            return wordList;
        }

        public List<int> GetAnagramsId(IEnumerable<string> anagrams)
        {
            var anagramList = new List<WordEntity>();
            anagrams = anagrams.ToList();
            //anagramList = _context.Word.Where(x => x.Word1.Equals(anagrams)).ToList();
            anagramList = _context.Word.Where(x => anagrams.Contains(x.Word1)).ToList();
            var anagramIdList = anagramList.Select(x => x.Id).ToList();

            return anagramIdList;
        }

        public List<string> GetCachedWords(string searchInput)
        {
            //var cachedwords = _context.CachedWord.Where(x => x.SearchWord == searchInput).ToList();
            //var cachedWordList = cachedwords.Select(x => x.SearchWord).ToList();
            var cachedAnagramList = from w in _context.Word
                                    from cw in _context.CachedWord
                                    where (cw.SearchWord == searchInput) && (cw.AnagramWordId == w.Id)
                                    select w.Word1;
            return cachedAnagramList.ToList();
        }

        public void InsertCachedWords(string searchInput, List<int> anagramsIdList)
        {
            var cachedWordEntity = new CachedWordEntity();
            foreach (var item in anagramsIdList)
            {
                cachedWordEntity = new CachedWordEntity{
                    SearchWord = searchInput,
                    AnagramWordId = item
                };
                _context.CachedWord.Add(cachedWordEntity);
            }
            //_context.CachedWord.Add(cachedWordEntity);
            _context.SaveChanges();
        }

    }
}
