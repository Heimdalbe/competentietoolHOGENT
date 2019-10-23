using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieTool.Controllers
{
    public class BedrijfController : Controller
    {
        private readonly IVacatureRepository _vacatureRepository;
        private readonly ICompetentieRepository _competentieRepository;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacaturesList()
        {
            //TODO(Joren): filter op bedrijf
            return View(_vacatureRepository.GetAll());
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

            var templist = new List<Competentie>();

            foreach (var item in vm.CompetentieIds)
            {
                if (!item.HeeftAanvulling || !IsSchrapOptie(item.AanvulOptieGeselecteerd, item.Id))
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

            foreach (var item in _competentieRepository.GetAll())
            {
                temp.CompetentieIds.Add(new CompetentieCheckboxViewModel
                {
                    Naam = item.Naam,
                    Id = item.Id,
                    Verklaring = item.Verklaring,
                    Aanvulling = item.Aanvulling?.Beschrijving,
                    AanvulOpties = item.Aanvulling?.Opties,
                    HeeftAanvulling = (item.Aanvulling != null),
                    IsSelected = IsCompetentieInVacature(vac, item.Id)
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

            foreach (var item in vm.CompetentieIds)
            {
                if (!item.HeeftAanvulling || !IsSchrapOptie(item.AanvulOptieGeselecteerd, item.Id))
                {
                    templist.Add(_competentieRepository.GetBy(item.Id));
                }
            }

            var temp = new Vacature
            {
                Id = vm.Id,
                Functie = vm.Functie,
                Beschrijving = vm.Beschrijving,
            };

            temp.CompetentiesLijst = new List<VacatureCompetentie>();

            temp.AddCompetenties(templist);

            _vacatureRepository.Update(temp);

            return Details(vm.Id);
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

        public BedrijfController(IVacatureRepository vacatureRepository, ICompetentieRepository competentieRepository)
        {
            _vacatureRepository = vacatureRepository;
            _competentieRepository = competentieRepository;
        }
    }
}