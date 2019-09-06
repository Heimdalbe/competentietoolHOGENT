using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class RegistratieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}