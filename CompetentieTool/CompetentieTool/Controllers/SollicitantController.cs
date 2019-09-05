using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Data.Repositories;
using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.ViewModels;
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
            
            ICollection<VraagViewModel> models = new List<VraagViewModel>();
            foreach(Competentie comp in vac.Competenties)
            {
                VraagViewModel res = new VraagViewModel();
                res.VraagStelling = comp.Vraag.VraagStelling;
                res.VraagId = comp.Vraag.Id;
                if(comp.Vraag is VraagCasus)
                {
                    res.Vignet = ((VraagCasus)comp.Vraag).Vignet.Beschrijving;
                    foreach(Mogelijkheid opt in ((VraagCasus)comp.Vraag).Opties)
                    {
                        res.opties.Add(opt.Beschrijving);
                    }
                }
                models.Add(res);
            }

            var results = models.GroupBy(m => m.Vignet).ToList();

            return View(results);
        }

        [HttpPost]
        public void Submit(List<IGrouping<string, VraagViewModel>> models)
        {
            foreach(var group in models)
            {
                
            }
        }
    }
}