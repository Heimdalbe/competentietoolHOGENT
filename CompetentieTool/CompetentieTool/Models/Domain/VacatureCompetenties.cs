using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class VacatureCompetenties
    {
        #region Properties
        public String VacatureId { get; set; }

        public String CompetentieId { get; set; }

        public Vacature Vacature { get; set; }

        public Competentie Competentie { get; set; }
        #endregion

    }
}
