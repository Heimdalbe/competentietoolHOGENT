using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class BedrijfController : Controller
    {
        private readonly IVacatureRepository _vacatureRepository;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacaturesList()
        {
            //TODO(Joren): filter op bedrijf
            return View(new List<Vacature>());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public BedrijfController(IVacatureRepository vacatureRepository)
        {
            _vacatureRepository = vacatureRepository;
        }
    }
}