using CompetentieTool.Models.Domain;
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
        public String Aanvulling { get; set; }
        public CompetentieType Type { get; set; }
        public List<Mogelijkheid> AanvulOpties { get; set; }
        public Mogelijkheid AanvulOptieGeselecteerd { get; set; }
        public bool HeeftAanvulling { get; set; }
    }
}
