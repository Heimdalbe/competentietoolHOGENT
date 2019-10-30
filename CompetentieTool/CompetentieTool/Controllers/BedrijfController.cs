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
            //TODO(Joren): filter op bedrijf$
            IEnumerable<Vacature> vacatures1 = _vacatureRepository.GetAll();
            IEnumerable<Vacature> vacatures2 = vacatures1.Where(v => v.organisatie != null && v.organisatie.Id.Equals(organisatie.Id));
            IEnumerable<Vacature> vacatures = _vacatureRepository.GetAll().Where(v => v.organisatie != null && v.organisatie.Id.Equals(organisatie.Id));
            var test = 1;
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
        public IActionResult Create(VacatureViewModel vm)
        {
            var temp = new Vacature
            {
                Functie = vm.Functie,
                Beschrijving = vm.Beschrijving,
            };
            temp.organisatie = (Organisatie) _userManager.GetUserAsync(HttpContext.User).Result;

            var templist = new List<Competentie>();

            foreach (var item in vm.CompetentieIds)
            {
                // als item geen aanvulling heeft OF schrapoptie niet is aangeduid
                if (item.HeeftAanvulling)
                {
                    temp.AddCompetentie(_competentieRepository.GetBy(item.Id), item.AanvulOptieGeselecteerd);
                }
                else
                {
                    templist.Add(_competentieRepository.GetBy(item.Id));
                }
            }

            temp.AddCompetenties(templist);

            _vacatureRepository.Add(temp);

            return RedirectToAction("VacaturesList");
        }

        private Boolean IsSchrapOptie(String expectedId, String competentieId)
        {
            var comp = _competentieRepository.GetBy(competentieId);

            if (comp.Aanvulling != null)
            {
                foreach (var item in comp.Aanvulling.Opties)
                {
                    if (item.IsSchrapOptie)
                    {
                        return item.Id.Equals(expectedId);
                    }
                }
            }
            return false;
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
                    HeeftAanvulling = (item.Aanvulling != null)
                });
            }

            return View(vm);
        }

        public IActionResult Edit(String id)
        {
            var vac = _vacatureRepository.GetBy(id);
            var temp = new VacatureViewModel(vac);

            foreach (var item in _vacatureRepository.GetVacatureCompetenties(id))
            {
                temp.CompetentieIds.Add(new CompetentieCheckboxViewModel
                {
                    Naam = item.Competentie.Naam,
                    Id = item.Competentie.Id,
                    Verklaring = item.Competentie.Verklaring,
                    Aanvulling = item.Competentie.Aanvulling?.Beschrijving,
                    AanvulOpties = item.Competentie.Aanvulling?.Opties,
                    HeeftAanvulling = (item.Competentie.Aanvulling != null),
                    AanvulOptieGeselecteerd = item.GeselecteerdeOptie
                });
            }

            return View(temp);
        }

        private bool IsCompetentieInVacature(Vacature vacature, String competentieId)
        {
            return vacature.CompetentiesLijst.Select(c => c.CompetentieId).Contains(competentieId);
        }

        [HttpPost]
        public IActionResult Edit(VacatureViewModel vm)
        {
            var templist = new List<Competentie>();

            var temp = new Vacature
            {
                Id = vm.Id,
                Functie = vm.Functie,
                Beschrijving = vm.Beschrijving,
            };

            temp.CompetentiesLijst = new List<VacatureCompetentie>();

            foreach (var item in vm.CompetentieIds)
            {
                if (item.HeeftAanvulling)
                {
                    temp.AddCompetentie(_competentieRepository.GetBy(item.Id), item.AanvulOptieGeselecteerd);
                }
                else
                {
                    templist.Add(_competentieRepository.GetBy(item.Id));
                }
            }

            temp.AddCompetenties(templist);

            _vacatureRepository.Update(temp);

            return RedirectToAction("VacaturesList");
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