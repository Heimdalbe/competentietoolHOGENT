﻿using CompetentieTool.Domain;
using System;

namespace CompetentieTool.Models.Domain
{
    public class VacatureCompetenties
    {
        public String VacatureId { get; set; }
        public String CompetentieId { get; set; }
        public Vacature Vacature { get; set; }
        public Competentie Competentie { get; set; }
    }
}