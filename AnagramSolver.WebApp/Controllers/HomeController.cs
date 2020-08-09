using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramSolver.WebApp.Models;
using System.Text.Encodings.Web;
using AnagramSolver.Interfaces;
using Microsoft.Extensions.Configuration;
using AnagramSolver.UI;

namespace AnagramSolver.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnagramSolver _anagramSolver;
        private readonly IDatabaseLogic _databaseLogic;

        public HomeController(IAnagramSolver anagramSolver, IDatabaseLogic databaseLogic)
        {
           _anagramSolver = anagramSolver;
            _databaseLogic = databaseLogic;
        }

        public IActionResult Index(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Error! At least one word must be entered.");
                var check = _databaseLogic.GetCachedWords(id);
                if (check.Count == 0)
                {
                    var anagrams = _anagramSolver.GetAnagrams(id);
                    var anagramsId = _databaseLogic.GetAnagramsId(anagrams);
                    _databaseLogic.InsertCachedWords(id, anagramsId);
                    return View(anagrams);
                }
                else
                {
                    var anagramsFromCache = _databaseLogic.GetCachedWords(id);
                    return View(anagramsFromCache);
                }

                //return View(anagrams);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
