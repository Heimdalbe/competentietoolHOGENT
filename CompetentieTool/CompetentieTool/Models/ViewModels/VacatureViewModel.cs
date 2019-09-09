using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class VacatureViewModel
    {
        private readonly ICompetentieRepository _competentieRepository;

        [Required]
        public String Id { get; set; }

        [Required]
        public String Functie { get; set; }

        [Required]
        public String Beschrijving { get; set; }

        [Required]
        public IEnumerable<Competentie> AlleCompetenties
        {
            get { return _competentieRepository.GetBasisCompetenties(); }
        }

        [Required]
        public IEnumerable<VacatureCompetentie> VacatureCompetenties { get; set; }

        public Boolean IsInVacatureCompetenties(string id)
        {
            return !String.IsNullOrEmpty(VacatureCompetenties.FirstOrDefault(c => c.CompetentieId.Equals(id))?.CompetentieId);
        }

        public VacatureViewModel()
        {
            
        }

        public VacatureViewModel(ICompetentieRepository competentieRepository)
        {
            _competentieRepository = competentieRepository;
            var temp = new Vacature();
            temp.AddCompetenties(competentieRepository.GetBasisCompetenties().ToList());
            VacatureCompetenties = temp.CompetentiesLijst;
        }

        public VacatureViewModel(ICompetentieRepository competentieRepository, Vacature temp)
        {
            this._competentieRepository = competentieRepository;
            Id = temp.Id;
            Functie = temp.Functie;
            Beschrijving = temp.Beschrijving;
            VacatureCompetenties = temp.CompetentiesLijst;
        }
    }
}
