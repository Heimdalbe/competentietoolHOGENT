using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class BedrijfController : Controller
    {
        private readonly IVacatureRepository _vacatureRepository;
        private readonly ICompetentieRepository _competentieRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIngevuldeVacatureRepository _ingevuldeVacatureRepository;

        public BedrijfController(IVacatureRepository vacatureRepository, ICompetentieRepository competentieRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IIngevuldeVacatureRepository ingevuldeVacatureRepository)
        {
            _vacatureRepository = vacatureRepository;
            _competentieRepository = competentieRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _ingevuldeVacatureRepository = ingevuldeVacatureRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacaturesList()
        {
            var organisatie = (Organisatie)_userManager.GetUserAsync(HttpContext.User).Result;
            IEnumerable<Vacature> vacatures = _vacatureRepository.GetAll().Where(v => v.organisatie != null && v.organisatie.Id.Equals(organisatie.Id));

            return View(vacatures);
        }

        public IActionResult Create()
        {
            var temp = new VacatureViewModel();

            var vac = new Vacature();
            vac.AddCompetenties(_competentieRepository.GetBasisCompetenties().ToList());
            temp.VacatureCompetenties = vac.CompetentiesLijst.Select(c => c.CompetentieId).ToList();

            return View(temp);
        }

        [HttpPost]
        [RequestSizeLimitAttribute(4000)]
        public IActionResult Create(VacatureViewModel vm)
        {
            var temp = new Vacature
            {
                Functie = vm.Functie,
                Beschrijving = vm.Beschrijving,
            };
            temp.organisatie = (Organisatie) _userManager.GetUserAsync(HttpContext.User).Result;

            var templist = new List<Competentie>();

            foreach (var item in vm.CompetentieGrondhoudingAanTeVullenIds)
            {
                if (!IsSchrapOptie(item.AanvulOptieGeselecteerd, item.Id))
                {
                    var comp = _competentieRepository.GetBy(item.Id);
                    temp.AddCompetentie(comp, comp.Aanvulling.Opties.FirstOrDefault(o => o.Id.Equals(item.AanvulOptieGeselecteerd)));
                }

            }
            foreach (var item in vm.CompetentieKennisAanTeVullenIds)
            {
                if (!IsSchrapOptie(item.AanvulOptieGeselecteerd, item.Id))
                {
                    var comp = _competentieRepository.GetBy(item.Id);
                    temp.AddCompetentie(comp, comp.Aanvulling.Opties.FirstOrDefault(o => o.Id.Equals(item.AanvulOptieGeselecteerd)));
                }
            }
            foreach (var item in vm.CompetentieVaardighedenAanTeVullenIds)
            {
                if (!IsSchrapOptie(item.AanvulOptieGeselecteerd, item.Id))
                {
                    var comp = _competentieRepository.GetBy(item.Id);
                    temp.AddCompetentie(comp, comp.Aanvulling.Opties.FirstOrDefault(o => o.Id.Equals(item.AanvulOptieGeselecteerd)));
                }
            }

            foreach (var item in vm.CompetentieGrondhoudingBasisIds)
            {
                templist.Add(_competentieRepository.GetBy(item.Id));
            }
            if(vm.CompetentieKennisBasisIds != null)
            {
    foreach (var item in vm.CompetentieKennisBasisIds)
                {
                    templist.Add(_competentieRepository.GetBy(item.Id));
                }
            }
            
            foreach (var item in vm.CompetentieVaardighedenBasisIds)
            {
                templist.Add(_competentieRepository.GetBy(item.Id));
            }

            temp.AddCompetenties(templist);

            _vacatureRepository.Add(temp);

            return RedirectToAction("VacaturesList");
        }

        private Boolean IsSchrapOptie(String expectedId, String competentieId)
        {
            var comp = _competentieRepository.GetBy(competentieId);
            return comp.Aanvulling.Opties.FirstOrDefault(o => o.Id.Equals(expectedId)).IsSchrapOptie;
        }

        public IActionResult SelecteerCompetenties(VacatureViewModel vm)
        {

            foreach (var item in _competentieRepository.GetAll())
            {
                vm.CompetentieIds.Add(new CompetentieCheckboxViewModel
                {
                    Naam = item.Naam,
                    Id = item.Id,
                    Verklaring = item.Verklaring,
                    Aanvulling = item.Aanvulling?.Beschrijving,
                    AanvulOpties = item.Aanvulling?.Opties,
                    HeeftAanvulling = (item.Aanvulling != null),
                    Type = item.Type
                });

                }
            vm.CompetentieGrondhoudingAanTeVullenIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.GRONDHOUDING) && c.HeeftAanvulling).ToList();
            vm.CompetentieKennisAanTeVullenIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.KENNIS) && c.HeeftAanvulling).ToList();
            vm.CompetentieVaardighedenAanTeVullenIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.VAARDIGHEDEN) && c.HeeftAanvulling).ToList();

            vm.CompetentieGrondhoudingBasisIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.GRONDHOUDING) && !c.HeeftAanvulling).ToList();
            vm.CompetentieKennisBasisIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.KENNIS) && !c.HeeftAanvulling).ToList();
            vm.CompetentieVaardighedenBasisIds = vm.CompetentieIds.Where(c => c.Type.Equals(CompetentieType.VAARDIGHEDEN) && !c.HeeftAanvulling).ToList();


            return View(vm);
        }

        public IActionResult Delete(String id)
        {
            var vac = _vacatureRepository.GetBy(id);
            var temp = new VacatureViewModel(vac);

            return View(temp);
        }

        [HttpPost]
        public IActionResult DeletePost(String id)
        {
            _vacatureRepository.Delete(id);

            return RedirectToAction("VacaturesList");
        }

        public IActionResult Details(String id)
        {
            var vac = _vacatureRepository.GetBy(id);
            var temp = new VacatureViewModel(vac);

            return View(temp);
        }

        public IActionResult Inzendingen(String id)
        {
            IEnumerable<IngevuldeVacature> ingevuldeVacatures = _ingevuldeVacatureRepository.GetAllByVacature(id);
            return View(ingevuldeVacatures);
        }
    }
}