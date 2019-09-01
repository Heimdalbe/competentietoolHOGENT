using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data.Repositories
{
    public class VacatureRepository : IVacatureRepository
    {
        private readonly ApplicationDbContext _context;

        public VacatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacature> GetAll()
        {
            return _context.Vacatures;
        }

        public Vacature GetBy(string id)
        {
            return _context.Vacatures.Where(v => v.Id.Equals(id)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
