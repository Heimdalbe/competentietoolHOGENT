using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class huhsofieisblondwhut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aanvulling",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvulling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Usertype = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Gsm = table.Column<string>(nullable: true),
                    Geslacht = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Nationaliteit = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Straat = table.Column<string>(nullable: true),
                    Huisnummer = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    OrganisatieNaam = table.Column<string>(nullable: true),
                    BtwNummer = table.Column<string>(nullable: true),
                    Opleidingsniveau = table.Column<int>(nullable: true),
                    Opleiding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vignet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vignet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacature",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Functie = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    organisatieId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacature_AspNetUsers_organisatieId",
                        column: x => x.organisatieId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vragen",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VraagStelling = table.Column<string>(nullable: true),
                    CompetentieId = table.Column<string>(nullable: true),
                    OutputString = table.Column<string>(nullable: true),
                    VignetId = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vragen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vragen_Vignet_VignetId",
                        column: x => x.VignetId,
                        principalTable: "Vignet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngevuldeVacatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VacatureId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngevuldeVacatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngevuldeVacatures_Vacature_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "Vacature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competenties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Verklaring = table.Column<string>(nullable: true),
                    IsBasisCompetentie = table.Column<bool>(nullable: false),
                    VraagId = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    AanvullingId = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competenties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competenties_Aanvulling_AanvullingId",
                        column: x => x.AanvullingId,
                        principalTable: "Aanvulling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competenties_Vragen_VraagId",
                        column: x => x.VraagId,
                        principalTable: "Vragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mogelijkheid",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Input = table.Column<string>(nullable: true),
                    Output = table.Column<string>(nullable: true),
                    Aanvulling = table.Column<string>(nullable: true),
                    IsSchrapOptie = table.Column<bool>(nullable: false),
                    AanvullingId = table.Column<string>(nullable: true),
                    VraagMeerkeuzeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mogelijkheid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mogelijkheid_Aanvulling_AanvullingId",
                        column: x => x.AanvullingId,
                        principalTable: "Aanvulling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mogelijkheid_Vragen_VraagMeerkeuzeId",
                        column: x => x.VraagMeerkeuzeId,
                        principalTable: "Vragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacatureCompetentie",
                columns: table => new
                {
                    VacatureId = table.Column<string>(nullable: false),
                    CompetentieId = table.Column<string>(nullable: false),
                    GeselecteerdeOptie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacatureCompetentie", x => new { x.VacatureId, x.CompetentieId });
                    table.ForeignKey(
                        name: "FK_VacatureCompetentie_Competenties_CompetentieId",
                        column: x => x.CompetentieId,
                        principalTable: "Competenties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacatureCompetentie_Vacature_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "Vacature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OptieKeuzeId = table.Column<string>(nullable: true),
                    Aanvulling = table.Column<string>(nullable: true),
                    VraagId = table.Column<string>(nullable: true),
                    IngevuldeVacatureId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_IngevuldeVacatures_IngevuldeVacatureId",
                        column: x => x.IngevuldeVacatureId,
                        principalTable: "IngevuldeVacatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                        column: x => x.OptieKeuzeId,
                        principalTable: "Mogelijkheid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Vragen_VraagId",
                        column: x => x.VraagId,
                        principalTable: "Vragen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Competenties_AanvullingId",
                table: "Competenties",
                column: "AanvullingId");

            migrationBuilder.CreateIndex(
                name: "IX_Competenties_VraagId",
                table: "Competenties",
                column: "VraagId",
                unique: true,
                filter: "[VraagId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IngevuldeVacatures_VacatureId",
                table: "IngevuldeVacatures",
                column: "VacatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Mogelijkheid_AanvullingId",
                table: "Mogelijkheid",
                column: "AanvullingId");

            migrationBuilder.CreateIndex(
                name: "IX_Mogelijkheid_VraagMeerkeuzeId",
                table: "Mogelijkheid",
                column: "VraagMeerkeuzeId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_IngevuldeVacatureId",
                table: "Response",
                column: "IngevuldeVacatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_OptieKeuzeId",
                table: "Response",
                column: "OptieKeuzeId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_VraagId",
                table: "Response",
                column: "VraagId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacature_organisatieId",
                table: "Vacature",
                column: "organisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_VacatureCompetentie_CompetentieId",
                table: "VacatureCompetentie",
                column: "CompetentieId");

            migrationBuilder.CreateIndex(
                name: "IX_Vragen_VignetId",
                table: "Vragen",
                column: "VignetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "VacatureCompetentie");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "IngevuldeVacatures");

            migrationBuilder.DropTable(
                name: "Mogelijkheid");

            migrationBuilder.DropTable(
                name: "Competenties");

            migrationBuilder.DropTable(
                name: "Vacature");

            migrationBuilder.DropTable(
                name: "Aanvulling");

            migrationBuilder.DropTable(
                name: "Vragen");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vignet");
        }
    }
}
