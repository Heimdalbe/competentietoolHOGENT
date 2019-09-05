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
        public String Vignet { get; set; }
        public ICollection<String> opties { get; set; }
        public String OptieKeuze { get; set; }
        public String Redenering { get; set; }

        public VraagViewModel()
        {
            opties = new List<String>();
        }
    }
}
