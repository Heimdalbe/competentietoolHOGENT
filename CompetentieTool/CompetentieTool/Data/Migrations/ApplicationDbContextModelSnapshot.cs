﻿// <auto-generated />
using System;
using CompetentieTool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompetentieTool.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompetentieTool.Domain.Competentie", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschrijving");

                    b.Property<string>("Naam");

                    b.Property<string>("Verklaring");

                    b.Property<string>("VraagId");

                    b.HasKey("Id");

                    b.HasIndex("VraagId")
                        .IsUnique()
                        .HasFilter("[VraagId] IS NOT NULL");

                    b.ToTable("Competenties");
                });

            modelBuilder.Entity("CompetentieTool.Domain.IVraag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompetentieId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("VraagStelling");

                    b.HasKey("Id");

                    b.ToTable("IVraag");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IVraag");
                });

            modelBuilder.Entity("CompetentieTool.Domain.Vignet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschrijving");

                    b.HasKey("Id");

                    b.ToTable("Vignet");
                });

            modelBuilder.Entity("CompetentieTool.Models.Domain.Mogelijkheid", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschrijving");

                    b.Property<string>("VraagCasusId");

                    b.HasKey("Id");

                    b.HasIndex("VraagCasusId");

                    b.ToTable("Mogelijkheid");
                });

            modelBuilder.Entity("CompetentieTool.Models.Domain.Vacature", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschrijving");

                    b.Property<string>("Functie");

                    b.HasKey("Id");

                    b.ToTable("Vacatures");
                });

            modelBuilder.Entity("CompetentieTool.Models.Domain.VacatureCompetenties", b =>
                {
                    b.Property<string>("VacatureId");

                    b.Property<string>("CompetentieId");

                    b.HasKey("VacatureId", "CompetentieId");

                    b.HasIndex("CompetentieId");

                    b.ToTable("VacatureCompetenties");
                });

            modelBuilder.Entity("CompetentieTool.Models.Identities.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CompetentieTool.Models.Identities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Achternaam");

                    b.Property<string>("Adres");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("GeboorteDatum");

                    b.Property<string>("Geboorteplaats");

                    b.Property<int>("GebruikersID");

                    b.Property<string>("Gemeente");

                    b.Property<string>("Geslacht");

                    b.Property<string>("Gsm");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nationaliteit");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Postcode");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CompetentieTool.Domain.VraagCasus", b =>
                {
                    b.HasBaseType("CompetentieTool.Domain.IVraag");

                    b.Property<string>("VignetId");

                    b.HasIndex("VignetId");

                    b.ToTable("VraagCasus");

                    b.HasDiscriminator().HasValue("VraagCasus");
                });

            modelBuilder.Entity("CompetentieTool.Domain.Competentie", b =>
                {
                    b.HasOne("CompetentieTool.Domain.IVraag", "Vraag")
                        .WithOne("Competentie")
                        .HasForeignKey("CompetentieTool.Domain.Competentie", "VraagId");
                });

            modelBuilder.Entity("CompetentieTool.Models.Domain.Mogelijkheid", b =>
                {
                    b.HasOne("CompetentieTool.Domain.VraagCasus")
                        .WithMany("Opties")
                        .HasForeignKey("VraagCasusId");
                });

            modelBuilder.Entity("CompetentieTool.Models.Domain.VacatureCompetenties", b =>
                {
                    b.HasOne("CompetentieTool.Domain.Competentie", "Competentie")
                        .WithMany()
                        .HasForeignKey("CompetentieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CompetentieTool.Models.Domain.Vacature", "Vacature")
                        .WithMany("CompetentiesLijst")
                        .HasForeignKey("VacatureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CompetentieTool.Models.Identities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CompetentieTool.Models.Identities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CompetentieTool.Models.Identities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CompetentieTool.Models.Identities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CompetentieTool.Models.Identities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CompetentieTool.Models.Identities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompetentieTool.Domain.VraagCasus", b =>
                {
                    b.HasOne("CompetentieTool.Domain.Vignet", "Vignet")
                        .WithMany()
                        .HasForeignKey("VignetId");
                });
#pragma warning restore 612, 618
        }
    }
}
