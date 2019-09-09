using CompetentieTool.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Sollicitant:ApplicationUser
    {
        private string _opleidingsniveau;
        private string _opleidingsnaam;


        public string Opleidingsniveau;
        public string Opleidingsnaam;
    }
}
