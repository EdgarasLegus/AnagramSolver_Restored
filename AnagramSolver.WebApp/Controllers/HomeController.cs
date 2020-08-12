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
using AnagramSolver.Interfaces.DBFirst;
using AnagramSolver.EF.CodeFirst;
using System.Reflection.Metadata.Ecma335;

namespace AnagramSolver.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnagramSolver _anagramSolver;
        private readonly IDatabaseLogic _databaseLogic;
        private readonly IEFLogic _eflogic;
        private readonly IEFRepository _eFRepository;

        public HomeController(IAnagramSolver anagramSolver, IDatabaseLogic databaseLogic, IEFLogic efLogic, IEFRepository eFRepository)
        {
           _anagramSolver = anagramSolver;
            _databaseLogic = databaseLogic;
            _eflogic = efLogic;
            _eFRepository = eFRepository;
        }

        public IActionResult Index(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Error! At least one word must be entered.");

                //Checking if CodeFirst Word table is empty
                //var context = new AnagramSolverCodeFirstContext();
                //if (!context.Word.Any())
                //{
                //    var fileColumns = _eFRepository.GetWordEntityFromFile();
                //    _eFRepository.InsertWordTableData(fileColumns);
                //}

                ////var check = _databaseLogic.GetCachedWords(id);
                _eflogic.InsertUserLog(id);
                var check = _eflogic.GetCachedWords(id);
                if (check.Count == 0)
                {
                    var anagrams = _anagramSolver.GetAnagrams(id);
                    //var anagramsId = _databaseLogic.GetAnagramsId(anagrams);
                    var anagramsId = _eflogic.GetAnagramsId(anagrams);
                    //_databaseLogic.InsertCachedWords(id, anagramsId);
                    _eflogic.InsertCachedWords(id, anagramsId);
                    return View(anagrams);
                }
                else
                {
                    //var anagramsFromCache = _databaseLogic.GetCachedWords(id);
                    var anagramsFromCache = _eflogic.GetCachedWords(id);
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
