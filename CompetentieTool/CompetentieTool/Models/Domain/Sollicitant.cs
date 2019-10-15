using CompetentieTool.Areas.Identity.Pages.Account;
using CompetentieTool.Models.Identities;
using CompetentieTool.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Sollicitant:ApplicationUser
    {
        private Opleidingsniveau _opleidingsniveau;
        private string _opleidingsnaam;


        public Opleidingsniveau Opleidingsniveau { get; set; }
        public string Opleiding { get; set; }
        

        public override void SetGegevensWerkgever(RegisterModel.InputModel input)
        {
            throw new InvalidOperationException("Gebruiker is geen werkgever");
        }

        public override void SetGegevensSollicitant(RegisterSollicitantModel.InputModel input)
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
            Opleidingsniveau = input.Opleidingsniveau;
            Opleiding = input.Opleiding;
        }

        public override string GetType()
        {
            return "Sollicitant";
        }

        public override void wijzigGegevens(ProfielViewModel viewmodel)
        {
            Achternaam = viewmodel.Achternaam;
            Voornaam = viewmodel.Voornaam;
            Geboortedatum = viewmodel.Geboortedatum;
            Gsm = viewmodel.Gsm;
            Geslacht = viewmodel.Geslacht;
            Nationaliteit = viewmodel.Nationaliteit;
            Gemeente = viewmodel.Gemeente;
            Postcode = viewmodel.Postcode;
            Straat = viewmodel.Straat;
            Huisnummer = viewmodel.Huisnummer;
            this.Email = viewmodel.Email;
            this.UserName = viewmodel.Email;
            Opleidingsniveau = viewmodel.Opleidingsniveau;
            Opleiding = viewmodel.Opleiding;
        }
    }
}
