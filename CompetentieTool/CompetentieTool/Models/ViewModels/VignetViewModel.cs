using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class VignetViewModel
    {
        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public List<CompetentieCheckboxViewModel> Competenties { get; set; }
    }
}
