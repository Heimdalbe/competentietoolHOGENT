using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models
{
    public enum Opleidingsniveau
    {
        [Display(Name = "Basis Onderwijs")]
        Basis_Onderwijs,
        [Display(Name = "Secundair Onderwijs (ASO/TSO)")]
        Secundair_Onderwijs,
        [Display(Name = "Hoger Beroepsonderwijs")]
        Hoger_beroepsonderwijs,
        [Display(Name = "Hoger Onderwijs, Academische Bachelor")]
        Academische_Bachelor,
        [Display(Name = "Hoger Onderwijs, Professionele Bachelor")]
        Professionele_Bachelor,
        [Display(Name = "Hoger Onderwijs, Master")]
        Master,
        [Display(Name = "Doctor")]
        Doctor
    }
}
