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

        public int GetAantalByVacature(Vacature vac)
        {
            return _context.IngevuldeVacatures.Include(s => s.Vacature)
                .Where(v => v.Vacature.Id.Equals(vac.Id)).Count();
        }

        public IEnumerable<IngevuldeVacature> GetAll()
        {
            return _context.IngevuldeVacatures
                //.Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(c => c.Vraag)
                //.Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(co => co.Vraag).ThenInclude(v => v.Vignet)
                //.Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.GeselecteerdeOptie)
                //.Include(i => i.Vacature).ThenInclude(i => i.organisatie)
                //.Include(i => i.Responses).ThenInclude(r => r.OptieKeuze)
                .Include(i => i.Vacature);
        }

        public IEnumerable<IngevuldeVacature> GetAllByVacature(String id)
        {
            return _context.IngevuldeVacatures
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(co => co.Vignet)
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(co => co.Vragen)
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst)//.ThenInclude(c => c.GeselecteerdeOptie)
                .Include(i => i.Vacature).ThenInclude(i => i.organisatie)
                .Include(i => i.Responses).ThenInclude(r => r.OptieKeuze)
                .Where(v => v.Vacature.Id.Equals(id));
        }

        public IngevuldeVacature GetBy(string Id)
        {
            return _context.IngevuldeVacatures
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(co => co.Vignet)
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.Competentie).ThenInclude(co => co.Vragen)
                .Include(i => i.Vacature).ThenInclude(i => i.CompetentiesLijst).ThenInclude(c => c.GeselecteerdeOptie)
                .Include(i => i.Vacature).ThenInclude(i => i.organisatie)
                .Include(i => i.Responses).ThenInclude(r => r.OptieKeuze)
                .Where(v => v.Id.Equals(Id)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
