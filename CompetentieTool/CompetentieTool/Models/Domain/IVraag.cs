using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;

namespace CompetentieTool.Domain
{
    public class IVraag
    {
        public  String Id { get; set; }
        public String VraagStelling { get; set; }
        public Competentie Competentie { get; set; }
        public String CompetentieId { get; set; }
        public String OutputString { get; set; }
        public Vignet Vignet { get; set; }
        public VraagType type { get; set; }    }
}