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
        private ICompetentieRepository _competentieRepository;

        [Required]
        public String Id { get; set; }

        [Required]
        public String Functie { get; set; }

        [Required]
        public String Beschrijving { get; set; }

        [Required]
        public IEnumerable<VacatureCompetentie> VacatureCompetenties { get; set; }

        internal void SetCompetentieRepository(ICompetentieRepository competentieRepository)
        {
            this._competentieRepository = competentieRepository;
        }

        public Boolean IsInVacatureCompetenties(string id)
        {
            return !String.IsNullOrEmpty(VacatureCompetenties.FirstOrDefault(c => c.CompetentieId.Equals(id))?.CompetentieId);
        }

        public VacatureViewModel()
        {
        }

        public VacatureViewModel(Vacature temp)
        {
            Id = temp.Id;
            Functie = temp.Functie;
            Beschrijving = temp.Beschrijving;
            VacatureCompetenties = temp.CompetentiesLijst;
        }
    }
}
