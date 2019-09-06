using CompetentieTool.Areas.Identity.Pages.Account;
using CompetentieTool.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Identities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        private string _usertype;
        private string _achternaam;
        private string _voornaam;
        private string _gsm;
        private string _geslacht;
        private DateTime _geboorteDatum;
        private string _nationaliteit;
        private string _gemeente;
        private string _postcode;
        private string _straat;
        private string _huisnummer;

        #region Properties
        public string Usertype
        {
            get { return _usertype; }
            private set
            {
                _usertype = value;
            }

        }
        
        public string Achternaam {
            get { return _achternaam; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.Any(char.IsLetter))
                {
                    throw new ArgumentException();
                }
                _achternaam = value;
            }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.Any(char.IsLetter))
                {
                    throw new ArgumentException();
                }
                _voornaam = value;
            }
        }
        public string Gsm
        {
            get { return _gsm; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _gsm = value;
            }
        }
        public string Geslacht
        {
            get { return _geslacht; }
            
            set
                {
                    if (value == null || !Regex.Match(value, "[MVX]", RegexOptions.IgnoreCase).Success)
                        throw new ArgumentException(value);
                    _geslacht = value;
                }
        }
        public DateTime GeboorteDatum {
            get { return _geboorteDatum; }
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException();
                _geboorteDatum = value;
            }
        }
        public string Nationaliteit {
            get { return _nationaliteit; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _nationaliteit = value;
            }
        }
        public string Gemeente {
            get { return _gemeente; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _gemeente = value;
            }
        }
        public string Postcode {
            get { return _postcode; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.All(char.IsDigit))
                {
                    throw new ArgumentException();
                }
                _postcode = value;
            }
        }
        public string Straat {
            get { return _straat; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.Any(char.IsLetter))
                {
                    throw new ArgumentException();
                }
                _straat = value;
            }
        }
        public string Huisnummer
        {
            get { return _huisnummer; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.All(char.IsDigit))
                {
                    throw new ArgumentException();
                }
                _huisnummer = value;
            }
        }
        #endregion

        public void wijzigGegevens(ProfielViewModel viewmodel)
        {
            Achternaam = viewmodel.Achternaam;
            Voornaam = viewmodel.Voornaam;
            GeboorteDatum = viewmodel.GeboorteDatum;
            Gsm = viewmodel.Gsm;
            Geslacht = viewmodel.Geslacht;
            Nationaliteit = viewmodel.Nationaliteit;
            Gemeente = viewmodel.Gemeente;
            Postcode = viewmodel.Postcode;
            Straat = viewmodel.Straat;
            Huisnummer = viewmodel.Huisnummer;
            this.Email = viewmodel.Emailadres;
            this.UserName = viewmodel.Emailadres;
        }

        public void SetGegevensWerkgever(RegisterModel.InputModel input)
        {
            Usertype = "Werkgever";
            Achternaam = input.Achternaam;
            Voornaam = input.Voornaam;
            GeboorteDatum = input.Geboortedatum;
            Gsm = input.GsmNummer;
            Geslacht = input.Geslacht;
            Nationaliteit = input.Nationaliteit;
            Gemeente = input.Gemeente;
            Postcode = input.Postcode;
            Straat = input.Straat;
            Huisnummer = input.Huisnummer;
            this.Email = input.Email;
            this.UserName = input.Email;
        }
        public void SetGegevensSollicitant(RegisterSollicitantModel.InputModel input)
        {
            Usertype = "Sollicitant";
            Achternaam = input.Achternaam;
            Voornaam = input.Voornaam;
            GeboorteDatum = input.Geboortedatum;
            Gsm = input.GsmNummer;
            Geslacht = input.Geslacht;
            Nationaliteit = input.Nationaliteit;
            Gemeente = input.Gemeente;
            Postcode = input.Postcode;
            Straat = input.Straat;
            Huisnummer = input.Huisnummer;
            this.Email = input.Email;
            this.UserName = input.Email;
        }
    }
}
