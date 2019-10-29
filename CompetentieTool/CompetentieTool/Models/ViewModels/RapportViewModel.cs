using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class RapportViewModel
    {
        public String CompetentieNaam { get; set; }
        public String VraagStelling { get; set; }
        public String Vignet { get; set; }
        public String OptieKeuze{ get; set; }
        public String Redenering { get; set; }
        public String mail { get; set; }
        public RapportViewModel()
        {

        }
    }
}
