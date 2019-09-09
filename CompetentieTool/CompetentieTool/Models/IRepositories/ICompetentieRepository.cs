using CompetentieTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.IRepositories
{
    public interface ICompetentieRepository
    {
        IEnumerable<Competentie> GetAll();
        IEnumerable<Competentie> GetBasisCompetenties();
        Competentie GetBy(string id);
        void SaveChanges();
    }
}
