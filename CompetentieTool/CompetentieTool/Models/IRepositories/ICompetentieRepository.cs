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
        Competentie GetById(int id);
        void Add(Competentie user);
        void SaveChanges();
    }
}
