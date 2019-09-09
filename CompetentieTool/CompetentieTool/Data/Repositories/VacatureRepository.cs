using CompetentieTool.Domain;
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
            _vacatures = context.Vacature;
        }

        public void Add(Vacature vacature)
        {
            _vacatures.Add(vacature);
            SaveChanges();
        }

        public void Delete(string id)
        {
            _vacatures.Remove(_vacatures.Find(id));
            SaveChanges();
        }

        public IEnumerable<Vacature> GetAll()
        {
            return _context.Vacature;
        }

        public Vacature GetBy(string id)
        {
            return _vacatures.Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Vraag)
                .ThenInclude(v => (v as VraagCasus).Vignet)
                .Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Vraag)
                .ThenInclude(v => (v as VraagCasus).Opties)
                .Where(v => v.Id.Equals(id)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Vacature vacature)
        {
            _vacatures.Update(vacature);
            SaveChanges();
        }
    }
}