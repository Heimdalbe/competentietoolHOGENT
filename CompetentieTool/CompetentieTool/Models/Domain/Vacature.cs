using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Vacature
    {
        public String Functie { get; set; }

        public String Beschrijving { get; set; }

        public CompetentieProfiel Profiel { get; set; }
    }
}
