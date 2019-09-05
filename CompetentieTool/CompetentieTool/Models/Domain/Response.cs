using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Response
    {
        public String Id { get; set; }

        public String OptieKeuze { get; set; }
        public String Aanvulling { get; set; }
        public String VraagId { get; set; }
    }
}
