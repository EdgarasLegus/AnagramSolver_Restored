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
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

                var ip = HttpContext.Connection.RemoteIpAddress.ToString();
                var validationCheck = CheckSearchValidation(ip);

                if (validationCheck != "ok")
                {
                    ViewBag.Message = "Limit of searches was exceeded! In order to have more searches, check this page:";
                    return View();
                }
                else
                {
                    _efUserLogRepository.InsertUserLog(id, ip);
                    ////var check = _databaseLogic.GetCachedWords(id);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DictionaryAdditionForm([Bind("DictionaryWord, DictionaryCategory")] WordAdditionModel additionModel)
        {
            if (ModelState.IsValid)
            {
                var word = additionModel.DictionaryWord;
                var category = additionModel.DictionaryCategory;
                _efWordRepository.InsertAdditionalWord(word, category);
                ViewBag.Message = "New word added successfully! +1 search is added";
                return View();
            }
            return View();
        }

        private string CheckSearchValidation(string ip)
        {
            var ipCount = _efUserLogRepository.CheckUserLogIp(ip);
            var maxSearchesForIP = Contracts.Settings.GetSettingsMaxSearchesForIP();
            if (ipCount > maxSearchesForIP)
            {
                var validation = "failed";
                return validation;
            }
            else
            {
                var validation = "ok";
                return validation;
            }
        }

    }
}
