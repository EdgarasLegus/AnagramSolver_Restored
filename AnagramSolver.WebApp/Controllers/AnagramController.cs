using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnagramSolver.WebApp.Controllers
{
    public class AnagramController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
