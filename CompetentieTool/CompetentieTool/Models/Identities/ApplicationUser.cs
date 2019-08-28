using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Identities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        
        public int GebruikersID { get; set; }
        public string Emailadres { get; set; }
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
        public string Gsm { get; set; }
        public string Geslacht { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Geboorteplaats { get; set; }
        public string Nationaliteit { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public string Adres { get; set; }

        public void wijzigGegevens(ProfielViewModel viewmodel)
        {
            Achternaam = viewmodel.Achternaam;
            Voornaam = viewmodel.Voornaam;
            GeboorteDatum = viewmodel.GeboorteDatum;
            Emailadres = viewmodel.Emailadres;
            Gsm = viewmodel.Gsm;
            Geslacht = viewmodel.Geslacht;
            Geboorteplaats = viewmodel.Geboorteplaats;
            Nationaliteit = viewmodel.Nationaliteit;
            Gemeente = viewmodel.Gemeente;
            Postcode = viewmodel.Postcode;
            Adres = viewmodel.Adres;
        }
    }
}
