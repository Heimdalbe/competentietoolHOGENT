using CompetentieTool.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Bedrijf:ApplicationUser
    {
        private string _bedrijfsnaam;
        private string _btwnummer;


        public string Bedrijfsnaam { get; set; }
        public string BtwNummer { get; set; }


    }
}
