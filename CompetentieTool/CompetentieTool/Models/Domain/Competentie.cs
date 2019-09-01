using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Domain
{
    public class Competentie
    {
        public String Id { get; set; }
        public String Naam { get; set; }
        public String Verklaring { get; set; }
        public IVraag Vraag { get; set; }
        public String Beschrijving { get; set; }
        public Aanvulling Aanvulling { get; set; }
    }
}
