using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Response
    {
        public String Id { get; set; }

        public Mogelijkheid OptieKeuze { get; set; }
        public String OptieKeuzeId { get; set; }
        public String OpenAntwoord { get; set; }
        public IVraag Vraag { get; set; }
        public String VraagId { get; set; }
    }
}
