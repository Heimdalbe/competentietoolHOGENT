using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using CompetentieTool.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class VacatureViewModel
    {

        [Required]
        public String Id { get; set; }

        [Required]
        public String Functie { get; set; }

        [Required]
        public String Beschrijving { get; set; }

        [Required]
        public ICollection<string> VacatureCompetenties { get; set; }

        public Boolean IsInVacatureCompetenties(string id)
        {
            return !String.IsNullOrEmpty(VacatureCompetenties.FirstOrDefault(c => c.Equals(id)));
        }

        public List<CompetentieCheckboxViewModel> CompetentieIds { get; set; }

        public VacatureViewModel()
        {
            VacatureCompetenties = new List<string>();
            CompetentieIds = new List<CompetentieCheckboxViewModel>();
        }

        public VacatureViewModel(Vacature temp)
        {
            Id = temp.Id;
            Functie = temp.Functie;
            Beschrijving = temp.Beschrijving;
            CompetentieIds = new List<CompetentieCheckboxViewModel>();
            VacatureCompetenties = temp.CompetentiesLijst.Select(c => c.CompetentieId).ToList();
        }
    }
}
