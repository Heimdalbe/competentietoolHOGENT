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

        public String UrlLink => "https://localhost:44348/Sollicitant/vragenlijst/" + Id;

        public List<CompetentieCheckboxViewModel> CompetentieIds { get; set; }

        public List<CompetentieCheckboxViewModel> CompetentieGrondhoudingAanTeVullenIds { get; set; }
        public List<CompetentieCheckboxViewModel> CompetentieKennisAanTeVullenIds { get; set; }
        public List<CompetentieCheckboxViewModel> CompetentieVaardighedenAanTeVullenIds { get; set; }
        public List<CompetentieCheckboxViewModel> CompetentieGrondhoudingBasisIds { get; set; }
        public List<CompetentieCheckboxViewModel> CompetentieVaardighedenBasisIds { get; set; }

        public VacatureViewModel()
        {
            CompetentieIds = new List<CompetentieCheckboxViewModel>();
        }

        public VacatureViewModel(Vacature temp)
        {
            Id = temp.Id;
            Functie = temp.Functie;
            Beschrijving = temp.Beschrijving;
            CompetentieIds = new List<CompetentieCheckboxViewModel>();
        }
    }
}
