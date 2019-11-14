using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class SollicitantViewModel
    {
        public String Voornaam { get; set; }
        public String Achternaam { get; set; }
        public String EmailAdres { get; set; }
        public String TelefoonNummer { get; set; }
        public IList<Group<string, CompetentieViewModel>> Competenties { get; set; }
    }
}
