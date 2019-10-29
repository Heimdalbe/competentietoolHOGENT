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
        public IList<Response> Responses { get; set; }
        public Sollicitant Sollicitant { get; set; }
        public DateTime DatumIngevuld { get; set; }

        public IngevuldeVacature()
        {
            DatumIngevuld = DateTime.Now;
            Responses = new List<Response>();
        }
    }
}
