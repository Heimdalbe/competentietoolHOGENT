using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class VraagViewModel
    {
        public String VraagId { get; set; }
        public String VraagStelling { get; set; }
        public ICollection<Mogelijkheid> Opties { get; set; }
        public String OptieKeuzeId { get; set; }
        public String Redenering { get; set; }

        public VraagViewModel()
        {
            Opties = new List<Mogelijkheid>();
        }
    }
}
