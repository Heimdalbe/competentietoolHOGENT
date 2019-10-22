using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class TemplateOutput
    {
        public String uitleg { get; set; }
        public IEnumerable<Mogelijkheid> mogelijkheden { get; set; }
    }
}
