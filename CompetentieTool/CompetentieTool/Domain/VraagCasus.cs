using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Domain
{
    public class VraagCasus : IVraag
    {
        public Vignet Vignet { get; set; }
    }
}
