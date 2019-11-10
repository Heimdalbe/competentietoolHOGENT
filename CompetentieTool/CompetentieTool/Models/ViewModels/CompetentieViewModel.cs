using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class CompetentieViewModel
    {

        public ICollection<VraagViewModel> VraagViewModels { get; set; }
    }
}
