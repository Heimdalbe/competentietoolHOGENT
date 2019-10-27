using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Domain
{
    public class VraagCasus : IVraag
    {
        public IEnumerable<Mogelijkheid> Opties { get; set; }

    }
}
