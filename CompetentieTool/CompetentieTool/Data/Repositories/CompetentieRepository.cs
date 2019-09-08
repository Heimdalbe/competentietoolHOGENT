using CompetentieTool.Domain;
using CompetentieTool.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data.Repositories
{
    public class CompetentieRepository : ICompetentieRepository
    {

        public void Add(Competentie user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competentie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Competentie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competentie> GetBasisCompetenties()
        {
            return GetAll().Where(c => c.IsBasisCompetentie);
        }
    }
}
