using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Mogelijkheid
    {
        public String Id { get; set; }
        public String Input { get; set; }
        public String Output { get; set; }
        public String Aanvulling { get; set; }
        public bool IsSchrapOptie { get; set; }
        public int Score { get; set; }

    }
}
