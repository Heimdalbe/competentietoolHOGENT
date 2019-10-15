using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class CompetentieCheckboxViewModel
    {
        public String Naam { get; set; }
        public String Verklaring { get; set; }
        public String Id { get; set; }
        public bool IsSelected { get; set; }
    }
}
