using CompetentieTool.Domain;
using CompetentieTool.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data.Repositories
{
    public class CompetentieRepository : ICompetentieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Competentie> _competenties;

        public IEnumerable<Competentie> GetAll()
        {
            return _competenties;
        }

        public Competentie GetBy(string id)
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

        public CompetentieRepository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
            this._competenties = dbContext.Competenties;
        }
    }
}
