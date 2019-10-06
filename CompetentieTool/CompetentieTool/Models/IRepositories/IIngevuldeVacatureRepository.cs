using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.IRepositories
{
    public interface IIngevuldeVacatureRepository
    {
        IEnumerable<IngevuldeVacature> GetAll();
        IngevuldeVacature GetBy(string Id);
        void Add(IngevuldeVacature vac);
        void Delete(IngevuldeVacature vac);
        void SaveChanges();
    }
}
