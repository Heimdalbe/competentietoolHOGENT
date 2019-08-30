using System;
using System.Collections.Generic;
using System.Text;
using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CompetentieTool.Models.Domain;

namespace CompetentieTool.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CompetentieTool.Models.Domain.Vacature> Vacature { get; set; }
    }
}
