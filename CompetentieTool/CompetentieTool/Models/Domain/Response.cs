﻿using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Response
    {
        public String Id { get; set; }

        public Mogelijkheid OptieKeuze { get; set; }
        public String Aanvulling { get; set; }
        public IVraag Vraag { get; set; }
    }
}
