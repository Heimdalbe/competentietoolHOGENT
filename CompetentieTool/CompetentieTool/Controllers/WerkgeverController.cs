using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class WerkgeverController : Controller
    {
        //[Authorize(Roles = "Werkgever")]
        public IActionResult Profielen()
        {
            return View();
        }
    }
}