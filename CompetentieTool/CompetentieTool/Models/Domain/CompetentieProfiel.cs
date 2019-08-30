﻿using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class CompetentieProfiel
    {
        public String Id { get; set; }
        public IEnumerable<Competentie> Competenties { get; set; }

        public CompetentieProfiel()
        {
        }
    }
}
