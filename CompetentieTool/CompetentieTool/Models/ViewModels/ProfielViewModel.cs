﻿
using CompetentieTool.Models.Domain;
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
        public Boolean IsSollicitant { get; set; }

        //[Required(ErrorMessage = "Opleiding is verplicht in te vullen")]
        public string Opleiding { get; set; }
        //[Required(ErrorMessage = "Opleidingsniveau is verplicht in te vullen")]
        public Opleidingsniveau Opleidingsniveau { get; set; }

        //[Required(ErrorMessage = "De naam van de organisatie is verplicht in te vullen")]
        public string OrganisatieNaam { get; set; }

        [Display(Name = "BTW/Organisatiesnummer")]
        //[Required(ErrorMessage = "BTW/Organisatienummer is verplicht in te vullen")]
        public string Btwnummer { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht in te vullen")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht in te vullen")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht in te vullen")]
        [DataType(DataType.Date)]
        //DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Geboortedatum { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht in te vullen")]
        public string Huisnummer { get; set; }

        [Required(ErrorMessage = "Straat is verplicht in te vullen")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht in te vullen")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Gemeente is verplicht in te vullen")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Nationaliteit is verplicht in te vullen")]
        public string Nationaliteit { get; set; }

        [Required(ErrorMessage = "Geslacht is verplicht in te vullen")]
        public string Geslacht { get; set; }

        [Display(Name = "Gsm nummer")]
        //[RegularExpression(@"^\+32[0-9]{9}$", ErrorMessage = "Een gsm nummer is van de vorm: +32470253698")]
        public string Gsm { get; set; }

        [Required(ErrorMessage = "Email is verplicht in te vullen")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig emailadres")]
        public string Email { get; set; }
        

        public ProfielViewModel()
        {
            

        }
        public ProfielViewModel(ApplicationUser user, Boolean bol) : this()
        {
            IsSollicitant = bol;
            Achternaam = user.Achternaam;
            Voornaam = user.Voornaam;
            Geboortedatum = user.Geboortedatum;
            Straat = user.Straat;
            Huisnummer = user.Huisnummer;
            Postcode = user.Postcode;
            Gemeente = user.Gemeente;
            Nationaliteit = user.Nationaliteit;
            Geslacht = user.Geslacht;
            Gsm = user.Gsm;
            Email = user.Email;
            var user2 = (Organisatie)user;
            Opleiding = "leeg";
            Opleidingsniveau = Opleidingsniveau.Basis_Onderwijs;
            OrganisatieNaam = user2.OrganisatieNaam;
            Btwnummer = user2.BtwNummer;
            }
        }

    }


