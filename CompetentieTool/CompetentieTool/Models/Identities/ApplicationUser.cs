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

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Stad { get; set; }
        public string Postcode { get; set; }
        public string Land { get; set; }
    }
}
