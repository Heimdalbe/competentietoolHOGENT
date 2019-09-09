using System;
using System.Collections.Generic;
using System.Text;
using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CompetentieTool.Models.Domain;
using CompetentieTool.Domain;

namespace CompetentieTool.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Vacature> Vacature { get; set; }
        public DbSet<Competentie> Competenties {get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Vacature>().Ignore(v => v.Competenties);

            builder.Entity<VacatureCompetentie>().HasKey(v => new { v.VacatureId, v.CompetentieId });
            builder.Entity<VacatureCompetentie>().HasOne(v => v.Vacature).WithMany(v => v.CompetentiesLijst).HasForeignKey(v => v.VacatureId);
            builder.Entity<VacatureCompetentie>().HasOne(v => v.Competentie).WithMany().HasForeignKey(v => v.CompetentieId);

        }
    }
}
