using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class ResponseGroup
    {
        public String Id { get; set; }
        public Competentie Competentie { get; set; }
        public IList<Response> Responses { get; set; }

        public ResponseGroup()
        {
            Responses = new List<Response>();
        }
    }
}
