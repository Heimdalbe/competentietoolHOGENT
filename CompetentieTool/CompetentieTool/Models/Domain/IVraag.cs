using CompetentieTool.Models.Domain;
using System;

namespace CompetentieTool.Domain
{
    public class IVraag
    {
        public  String Id { get; set; }
        public String VraagStelling { get; set; }
        public Competentie Competentie { get; set; }
        public String CompetentieId { get; set; }
        public TemplateInvulveld invulveld;
        public TemplateOutput output;
    }
}