using System;
using System.Collections.Generic;
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

        public AnagramController(IWordRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int? pageIndex, int pageSize = 100)
        {
            try
            {
                var wordList = _repository.GetWords().AsQueryable();
                return View(PaginatedList<Anagram>.CreateAsync((IQueryable<Anagram>)wordList, pageIndex ?? 1, pageSize));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
