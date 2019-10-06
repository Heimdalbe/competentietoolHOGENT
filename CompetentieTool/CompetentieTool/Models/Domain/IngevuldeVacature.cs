using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class IngevuldeVacature
    {
        public Vacature Vacature { get; set; }
        public IList<Response> responses { get; set; }

        public IngevuldeVacature()
        {
            responses = new List<Response>();
        }
    }
}
