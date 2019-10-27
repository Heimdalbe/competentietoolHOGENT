using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public class Vacature
    {
        public String Id { get; set; }

        public String Functie { get; set; }

        public String Beschrijving { get; set; }

        public IEnumerable<Competentie> Competenties => CompetentiesLijst.Select(c => c.Competentie);

        public ICollection<VacatureCompetentie> CompetentiesLijst { get; set; }

        public void AddCompetenties(ICollection<Competentie> competenties)
        {
            foreach (Competentie comp in competenties)
                AddCompetentie(comp);
        }

        public void AddCompetentie(Competentie competentie)
        {
            CompetentiesLijst.Add(new VacatureCompetentie
            {
                Vacature = this,
                VacatureId = this.Id,
                Competentie = competentie,
                CompetentieId = competentie.Id
            });
        }

        public void AddCompetentie(Competentie competentie, String geselecteerdeOptie)
        {
            CompetentiesLijst.Add(new VacatureCompetentie
            {
                Vacature = this,
                VacatureId = this.Id,
                Competentie = competentie,
                CompetentieId = competentie.Id,
                GeselecteerdeOptie = geselecteerdeOptie
            });
        }

        public Vacature()
        {
            CompetentiesLijst = new List<VacatureCompetentie>();
        }
    }
}
