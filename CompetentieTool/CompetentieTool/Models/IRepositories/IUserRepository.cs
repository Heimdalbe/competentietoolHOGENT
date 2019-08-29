using CompetentieTool.Models.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.Domain
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetByUsername(string username);
        void Add(ApplicationUser user);
        void SaveChanges();
    }
}
