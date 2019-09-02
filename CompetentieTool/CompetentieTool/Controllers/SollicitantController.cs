using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Data.Repositories;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class SollicitantController : Controller
    {
        private readonly IVacatureRepository _vacatureRepository;

        public SollicitantController(IVacatureRepository vacatureRepository)
        {
            this._vacatureRepository = vacatureRepository;
        }
        public IActionResult Vacatures()
        {
            IEnumerable<Vacature> vacatures = _vacatureRepository.GetAll();
            return View(vacatures);
        }

        public IActionResult Uitnodigingen()
        {
            return View();
        }

        public IActionResult Vragenlijst(String id)
        {
            Vacature vac = _vacatureRepository.GetBy(id);
            return View();
        }
    }
}