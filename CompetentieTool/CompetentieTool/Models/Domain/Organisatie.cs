using CompetentieTool.Areas.Identity.Pages.Account;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Organisatie:ApplicationUser
    {
        private string _bedrijfsnaam;
        private string _btwnummer;


        public string OrganisatieNaam { get; set; }
        public string BtwNummer { get; set; }

        public override string GetType()
        {
            return "Werkgever";
        }
        

        public override void SetGegevensWerkgever(RegisterModel.InputModel input)
        {
            Achternaam = input.Achternaam;
            Voornaam = input.Voornaam;
            Geboortedatum = input.Geboortedatum;
            Gsm = input.GsmNummer;
            Geslacht = input.Geslacht;
            Nationaliteit = input.Nationaliteit;
            Gemeente = input.Gemeente;
            Postcode = input.Postcode;
            Straat = input.Straat;
            Huisnummer = input.Huisnummer;
            this.Email = input.Email;
            this.UserName = input.Email;
            OrganisatieNaam = input.OrganisatieNaam;
            BtwNummer = input.Btwnummer;
        }

        public override void wijzigGegevens(ProfielViewModel input)
        {
            Achternaam = input.Achternaam;
            Voornaam = input.Voornaam;
            Geboortedatum = input.Geboortedatum;
            Gsm = input.Gsm;
            Geslacht = input.Geslacht;
            Nationaliteit = input.Nationaliteit;
            Gemeente = input.Gemeente;
            Postcode = input.Postcode;
            Straat = input.Straat;
            Huisnummer = input.Huisnummer;
            this.Email = input.Email;
            this.UserName = input.Email;
            OrganisatieNaam = input.OrganisatieNaam;
            BtwNummer = input.Btwnummer;
        }
    }
}
