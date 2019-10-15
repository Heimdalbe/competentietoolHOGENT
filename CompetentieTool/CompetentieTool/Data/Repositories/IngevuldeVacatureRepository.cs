using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data.Repositories
{
    public class IngevuldeVacatureRepository : IIngevuldeVacatureRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<IngevuldeVacature> _ingevuldeVacatures;

        public IngevuldeVacatureRepository(ApplicationDbContext context)
        {
            _context = context;
            _ingevuldeVacatures = _context.IngevuldeVacatures;
        }
        public void Add(IngevuldeVacature vac)
        {
            _ingevuldeVacatures.Add(vac);
            SaveChanges();
        }

        public void Delete(IngevuldeVacature vac)
        {
            _ingevuldeVacatures.Remove(vac);
            SaveChanges();
        }

        public IEnumerable<IngevuldeVacature> GetAll()
        {
            return _context.IngevuldeVacatures;
        }

        public IngevuldeVacature GetBy(string Id)
        {
            return _context.IngevuldeVacatures.Include(v => v.responses).Where(v => v.Id.Equals(Id)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
