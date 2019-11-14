using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class AntwoordViewModel
    {

        public String VraagStelling { get; set; }
        public String Antwoord { get; set; }
        public VraagType VraagType { get; set; }
    }
}
