using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class RapportViewModel
    {
        public String CompetentieNaam { get; set; }
        public String Vignet { get; set; }
        public CompetentieType CompetentieType { get; set; }
        public string Verklaring { get; set; }
        public IList<AntwoordViewModel> vms;

        public RapportViewModel()
        {
            vms = new List<AntwoordViewModel>();
        }
    }
}
