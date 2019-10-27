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
        private readonly IIngevuldeVacatureRepository _ingevuldeVacatureRepository;

        public SollicitantController(IVacatureRepository vacatureRepository, IIngevuldeVacatureRepository ingevuldeVacatureRepository)
        {
            this._vacatureRepository = vacatureRepository;
            _ingevuldeVacatureRepository = ingevuldeVacatureRepository;
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
                        res.opties.Add(opt);
                    }
                }
                models.Add(res);
            }

            ViewData["id"] = id;

            ICollection<Group<string, VraagViewModel>> groups = new List<Group<string, VraagViewModel>>();
            var results = models.GroupBy(m => m.Vignet).ToList();
            foreach(var item in results)
            {
                groups.Add(new Group<string, VraagViewModel> { Key = item.Key, Values = item.ToList() });
            }
            return View(groups);
        }

        [HttpPost]
        public IActionResult Submit(List<Group<string, VraagViewModel>> models, string id)
        {
            IngevuldeVacature vac = new IngevuldeVacature();
           vac.Vacature = _vacatureRepository.GetBy(id);
            foreach(var group in models)
            {
                foreach(var item in group.Values)
                {
                    vac.responses.Add(new Response { Aanvulling = item.Redenering, VraagId = item.VraagId, OptieKeuzeId = item.OptieKeuzeId });
                }
            }
            _ingevuldeVacatureRepository.Add(vac);
            int i = 1;
            return RedirectToAction("Index", "Home");
        }
    }
}