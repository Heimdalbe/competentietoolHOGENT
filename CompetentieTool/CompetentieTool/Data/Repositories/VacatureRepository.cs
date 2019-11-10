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
        private readonly DbSet<IVraag> _vragen;

        public VacatureRepository(ApplicationDbContext context)
        {
            _context = context;
            _vacatures = context.Vacature;
            _vragen = context.Vragen;
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
            return _context.Vacature.Include(v => v.organisatie);
        }

        public Vacature GetBy(string id)
        {
            return _vacatures.Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Vragen)
                .Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Vignet)
                .Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Vragen)
                .ThenInclude(v => (v as VraagMeerkeuze).Opties)
                .Include(v => v.CompetentiesLijst)
                .ThenInclude(c => c.Competentie)
                .ThenInclude(c => c.Aanvulling)
                .ThenInclude(a => a.Opties)
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

        public List<VacatureCompetentie> GetVacatureCompetenties(string vacatureId)
        {
            return GetAll().FirstOrDefault(v => v.Id.Equals(vacatureId)).CompetentiesLijst.ToList();
        }

        public VacatureCompetentie GetVacatureCompetentie(string id, string vacatureId)
        {
            return GetBy(vacatureId).CompetentiesLijst.FirstOrDefault(c => c.CompetentieId.Equals(id));
        }

        public IEnumerable<IVraag> GetAllQuestions()
        {
            return _vragen.Include(v => (v as VraagMeerkeuze).Opties);
        }
    }
}