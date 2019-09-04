using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class VacatureViewModel
    {

        [Required]
        public String Functie { get; set; }

        [Required]
        public String Beschrijving { get; set; }

    }
}
