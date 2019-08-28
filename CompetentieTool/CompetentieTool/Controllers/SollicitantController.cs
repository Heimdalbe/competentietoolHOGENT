using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class SollicitantController : Controller
    {
        public IActionResult Vacatures()
        {
            return View();
        }

        public IActionResult Uitnodigingen()
        {
            return View();
        }
    }
}