using System;
using System.Collections.Generic;
using System.Text;
using CompetentieTool.Domain;
using CompetentieTool.Models.Domain;
using CompetentieTool.Models.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompetentieTool.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Vacature> Vacature { get; set; }
        public DbSet<Competentie> Competenties {get; set; }
        public DbSet<Sollicitant> Sollicitanten { get; set; }
        public DbSet<Organisatie> Bedrijven { get; set; }
        public DbSet<IngevuldeVacature> IngevuldeVacatures { get; set; }

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

            builder.Entity<Competentie>().Ignore(c => c.Aanvulling);
            builder.Entity<Competentie>().HasOne(v => v.Vraag).WithOne(c => c.Competentie).HasForeignKey<Competentie>(c => c.VraagId);

            builder.Entity<IVraag>().HasKey(i => i.Id);
            

            builder.Entity<VraagCasus>().HasOne(v => v.Vignet).WithMany();
            builder.Entity<VraagCasus>().HasMany(v => v.Opties).WithOne();

            builder.Entity<IngevuldeVacature>().HasMany(v => v.responses).WithOne();
            builder.Entity<IngevuldeVacature>().HasOne(v => v.Vacature);
        }
    }
}
