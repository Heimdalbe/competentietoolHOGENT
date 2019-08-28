
using CompetentieTool.Models.Identities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class ProfielViewModel
    {
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime GeboorteDatum { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public int Postcode { get; set; }
        [Required]
        public string Gemeente { get; set; }
        [Required]
        public string Nationaliteit { get; set; }
        [Required]
        public string Geboorteplaats { get; set; }
        [Required]
        public string Geslacht { get; set; }
        public string Gsm { get; set; }
        [Required]
        public string Emailadres { get; set; }

        public ProfielViewModel()
        {


        }
        public ProfielViewModel(ApplicationUser user) : this()
        {
            Achternaam = user.Achternaam;
            Voornaam = user.Voornaam;
            GeboorteDatum = user.GeboorteDatum;
            Adres = user.Adres;
            Postcode = user.Postcode;
            Gemeente = user.Gemeente;
            Nationaliteit = user.Nationaliteit;
            Geboorteplaats = user.Geboorteplaats;
            Geslacht = user.Geslacht;
            Gsm = user.Gsm;
            Emailadres = user.Emailadres;

        }

    }

}
