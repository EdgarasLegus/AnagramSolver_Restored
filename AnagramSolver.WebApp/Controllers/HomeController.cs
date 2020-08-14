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
using AnagramSolver.Interfaces.EF;

namespace AnagramSolver.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnagramSolver _anagramSolver;
        private readonly IDatabaseLogic _databaseLogic;
        private readonly IEFLogic _eflogic;

        private readonly IEFWordRepo _efWordRepository;
        private readonly IEFUserLogRepo _efUserLogRepository;
        private readonly IEFCachedWordRepo _efCachedWordRepository;

        public HomeController(IAnagramSolver anagramSolver, IDatabaseLogic databaseLogic, IEFLogic efLogic, 
            IEFWordRepo efWordRepository, IEFUserLogRepo efUserLogRepository, IEFCachedWordRepo efCachedWordRepository)
        {
           _anagramSolver = anagramSolver;
            _databaseLogic = databaseLogic;
            _eflogic = efLogic;

            _efWordRepository = efWordRepository;
            _efUserLogRepository = efUserLogRepository;
            _efCachedWordRepository = efCachedWordRepository;
        }

        public IActionResult Index(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Error! At least one word must be entered.");

                //if (_efUserLogRepository.CheckUserLogIp() > Contracts.Settings.GetSettingsMaxSearchesForIP())
                    //throw new Exception("Limit of searches was exceeded!");
                    

                ////var check = _databaseLogic.GetCachedWords(id);
                _efUserLogRepository.InsertUserLog(id);
                var check = _efCachedWordRepository.GetCachedWords(id);
                if (check.Count == 0)
                {
                    var anagrams = _anagramSolver.GetAnagrams(id);
                    //var anagramsId = _databaseLogic.GetAnagramsId(anagrams);
                    var anagramsId = _efWordRepository.GetAnagramsId(anagrams);
                    //_databaseLogic.InsertCachedWords(id, anagramsId);
                    _efCachedWordRepository.InsertCachedWords(id, anagramsId);
                    return View(anagrams);
                }
                else
                {
                    //var anagramsFromCache = _databaseLogic.GetCachedWords(id);
                    var anagramsFromCache = _efCachedWordRepository.GetCachedWords(id);
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

        public IActionResult DisplayMessage(string message)
        {
            if (_efUserLogRepository.CheckUserLogIp() > Contracts.Settings.GetSettingsMaxSearchesForIP())
                return View(message);
            return RedirectToAction("Index");
        }
    }
}
