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
            
            
            return View(vacatures);
        }

        public IActionResult Uitnodigingen()
        {
            return View();
        }

        public IActionResult Vragenlijst(String id)
        {
            Vacature vac = _vacatureRepository.GetBy(id);

            ICollection<CompetentieViewModel> compModels = new List<CompetentieViewModel>();
            
            foreach(Competentie comp in vac.Competenties)
            {
                ICollection<IVraag> vragen = comp.Vragen.OrderBy(v => v.VraagVolgorde).ToList();
                IList<VraagViewModel> models = new List<VraagViewModel>();
                foreach (IVraag vraag in vragen) { 
                VraagViewModel res = new VraagViewModel();
                res.VraagStelling = vraag.VraagStelling;
                res.VraagId = vraag.Id;
                
                if(vraag is VraagMeerkeuze vraagMeerkeuze)
                {
                    foreach(Mogelijkheid opt in (vraagMeerkeuze).Opties)
                    {
                        res.Opties.Add(opt);
                    }
                }
                if (vraag is VraagRubrics vraagRubrics)
                {
                    foreach (Mogelijkheid opt in (vraagRubrics).Opties)
                    {
                        res.Opties.Add(opt);
                    }
                }
                models.Add(res);
            }
                
                CompetentieViewModel compM = new CompetentieViewModel() { VraagViewModels = models, Vignet = comp.Vignet?.Beschrijving };
                compModels.Add(compM);
            }

            ViewData["id"] = id;

            ICollection<Group<string, CompetentieViewModel>> groups = new List<Group<string, CompetentieViewModel>>();
            var results = compModels.GroupBy(m => m.Vignet).ToList();
            foreach(var item in results)
            {
                groups.Add(new Group<string, CompetentieViewModel> { Key = item.Key, Values = item.ToList() });
            }
            return View(groups);
        }

        [HttpPost]
        public IActionResult Submit(List<Group<string, CompetentieViewModel>> models, string id)
        {
            IngevuldeVacature vac = new IngevuldeVacature();
            vac.Vacature = _vacatureRepository.GetBy(id);
            IEnumerable<IVraag> vragen = _vacatureRepository.GetAllQuestions();
            IVraag vraag = null;
            Mogelijkheid optie = null;
            // Todo vervangen door velden voornaam, achternaam, email en telefoon
            //vac.Sollicitant = (Sollicitant) _userManager.GetUserAsync(HttpContext.User).Result;
             
            foreach (var group in models)
            {
                foreach(var comp in group.Values)
                {
                    foreach(var item in comp.VraagViewModels)
                    { 
                        vraag = vragen.SingleOrDefault(v => v.Id.Equals(item.VraagId));
                        if (vraag is VraagMeerkeuze)
                        {
                            optie = ((VraagMeerkeuze)vraag).Opties.SingleOrDefault(c => c.Id.Equals(item.OptieKeuzeId));
                            vac.Responses.Add(new Response { Vraag = vraag, OptieKeuze = optie });
                        }
                        else if( vraag is VraagRubrics)
                        {
                            optie = ((VraagRubrics)vraag).Opties.SingleOrDefault(c => c.Id.Equals(item.OptieKeuzeId));
                            vac.Responses.Add(new Response { Vraag = vraag, OptieKeuze = optie });
                        }
                        else
                        {
                            vac.Responses.Add(new Response { OpenAntwoord = item.Redenering, Vraag = vraag });
                        }
                        
                    }
                }
            }

            _ingevuldeVacatureRepository.Add(vac);
            int i = 1;
            return RedirectToAction("Index", "Home");
        }
    }
}