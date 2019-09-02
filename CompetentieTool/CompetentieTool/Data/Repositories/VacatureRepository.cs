using CompetentieTool.Models.Domain;
using CompetentieTool.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Data.Repositories
{
    public class VacatureRepository : IVacatureRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Vacature> _vacatures;

        public VacatureRepository(ApplicationDbContext context)
        {
            _context = context;
            _vacatures = context.Vacatures;
        }

        public IEnumerable<Vacature> GetAll()
        {
            return _context.Vacatures;
        }

        public Vacature GetBy(string id)
        {
            return _vacatures.Include(v => v.CompetentiesLijst).ThenInclude(c => c.Competentie).Where(v => v.Id.Equals(id)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
