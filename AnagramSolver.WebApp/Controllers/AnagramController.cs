using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AnagramSolver.Contracts;
using AnagramSolver.Interfaces;
using AnagramSolver.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnagramSolver.WebApp.Controllers
{
    public class AnagramController : Controller
    {
        private readonly IWordRepository _repository;
        private readonly IAnagramSolver _anagramSolver;

        public AnagramController(IWordRepository repository, IAnagramSolver anagramSolver)
        {
            _repository = repository;
            _anagramSolver = anagramSolver;
        }

        public IActionResult Index(int? pageIndex)
        {
            try
            {
                //var wordList = _repository.GetWords().AsQueryable();
                //return View(PaginatedList<Anagram>.CreateAsync((IQueryable<Anagram>)wordList, pageIndex ?? 1, pageSize));
                var wordList = _repository.GetWords()
                    .Select(x => new Anagram
                    {
                        Word = x.Key,
                        PartOfSpeech = x.Value
                    })
                    .AsQueryable();

                //var paginatedList = PaginatedList<Anagram>.CreateAsync(wordList, pageIndex ?? 1, pageSize);
                var paginatedList = PaginatedList<Anagram>.Create(wordList, pageIndex ?? 1, 100);

                return View(paginatedList);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult WordAnagrams(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Error! At least one word must be entered.");

                var anagrams = _anagramSolver.GetAnagrams(id);


                return View(anagrams);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
