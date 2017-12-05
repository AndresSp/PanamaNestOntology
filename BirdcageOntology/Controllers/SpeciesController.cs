using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;

namespace WebApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        

        [Route("viewspeciesdetail")]
        [HttpPost]
        public IActionResult ViewSpecie([FromBody] Bird bird)
        {
            return View(bird);
        }
    }
}