using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Data.Repositories;
using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class SollicitantController : Controller
    {
        private readonly IVacatureRepository _vacatureRepository;
        private readonly IIngevuldeVacatureRepository _ingevuldeVacatureRepository;

        private readonly UserManager<ApplicationUser> _userManager;

        public SollicitantController(IVacatureRepository vacatureRepository, IIngevuldeVacatureRepository ingevuldeVacatureRepository, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this._vacatureRepository = vacatureRepository;
            _ingevuldeVacatureRepository = ingevuldeVacatureRepository;
        }
        public IActionResult Vacatures()
        {
            IEnumerable<Vacature> vacatures = _vacatureRepository.GetAll();

            var sollicitant = (Sollicitant)_userManager.GetUserAsync(HttpContext.User).Result;
            IList<IngevuldeVacature> ingVacatures = _ingevuldeVacatureRepository.GetAll().Where(i => i.Sollicitant.Id.Equals(sollicitant.Id)).ToList();

            IList<Vacature> vacaturesSol = new List<Vacature>();
            foreach (Vacature vac in vacatures)
            {
                if(ingVacatures.SingleOrDefault(i => i.Vacature.Id.Equals(vac.Id)) == null)
                {
                    vacaturesSol.Add(vac);
                }
            }
            
            return View(vacaturesSol);
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
                foreach (IVraag vraag in comp.Vragen) { 
                VraagViewModel res = new VraagViewModel();
                res.VraagStelling = vraag.VraagStelling;
                res.VraagId = vraag.Id;
                res.Vignet = comp.Vignet?.Beschrijving;
                if(vraag is VraagMeerkeuze)
                {
                    foreach(Mogelijkheid opt in ((VraagMeerkeuze)vraag).Opties)
                    {
                        res.Opties.Add(opt);
                    }
                }
                if (vraag is VraagRubrics)
                {
                    foreach (Mogelijkheid opt in ((VraagRubrics)vraag).Opties)
                    {
                        res.Opties.Add(opt);
                    }
                }
                models.Add(res);
            }
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
            IEnumerable<IVraag> vragen = _vacatureRepository.GetAllQuestions();
            IVraag vraag = null;
            Mogelijkheid optie = null;
            vac.Sollicitant = (Sollicitant) _userManager.GetUserAsync(HttpContext.User).Result;
             
            foreach (var group in models)
            {
                foreach(var item in group.Values)
                {
                    vraag = vragen.SingleOrDefault(v => v.Id.Equals(item.VraagId));
                    if (vraag is VraagMeerkeuze)
                    {
                        optie = ((VraagMeerkeuze)vraag).Opties.SingleOrDefault(c => c.Id.Equals(item.OptieKeuzeId));
                    }
                    if( vraag is VraagRubrics)
                    {
                        optie = ((VraagRubrics)vraag).Opties.SingleOrDefault(c => c.Id.Equals(item.OptieKeuzeId));
                    }
                    vac.Responses.Add(new Response { OpenAntwoord = item.Redenering, Vraag = vraag, OptieKeuze= optie });
                }
            }

            _ingevuldeVacatureRepository.Add(vac);
            int i = 1;
            return RedirectToAction("Index", "Home");
        }
    }
}