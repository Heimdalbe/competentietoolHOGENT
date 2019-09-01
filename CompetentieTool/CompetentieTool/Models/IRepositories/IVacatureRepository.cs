using CompetentieTool.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.IRepositories
{
    public interface IVacatureRepository
    {
        IEnumerable<Vacature> GetAll();
        Vacature GetBy(string id);
        void SaveChanges();
    }
}
