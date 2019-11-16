using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class IngevuldeVacature
    {
        public string Id { get; set; }
        public Vacature Vacature { get; set; }
        public IList<ResponseGroup> ResponseGroup { get; set; }
        public String VoornaamSollicitant { get; set; }
        public String AchternaamSollicitant { get; set; }
        public String EmailSollicitant { get; set; }
        public String TelefoonSollicitant { get; set; }
        public DateTime DatumIngevuld { get; set; }
        public String VolledigeNaam
        {
            get { return VoornaamSollicitant + " " + AchternaamSollicitant; }
        }

        public IngevuldeVacature()
        {
            DatumIngevuld = DateTime.Now;
            ResponseGroup = new List<ResponseGroup>();
        }
    }
}
