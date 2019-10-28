using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;

namespace CompetentieTool.Domain
{
    public class Aanvulling
    {
        public String Id { get; set; }
        public String Beschrijving { get; set; }
        public List<Mogelijkheid> Opties { get; set; }
    }
}