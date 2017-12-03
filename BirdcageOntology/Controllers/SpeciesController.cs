using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Querie1()
        {
            return View();
        }

        public IActionResult Querie2()
        {
            return View();
        }
    }

}