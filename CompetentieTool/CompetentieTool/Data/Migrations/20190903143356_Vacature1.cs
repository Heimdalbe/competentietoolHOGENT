using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class Vacature1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aanvulling",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvulling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetentieProfiel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetentieProfiel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vraag",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vraag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacature",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Functie = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    ProfielId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacature_CompetentieProfiel_ProfielId",
                        column: x => x.ProfielId,
                        principalTable: "CompetentieProfiel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competentie",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Verklaring = table.Column<string>(nullable: true),
                    IsBasisCompetentie = table.Column<bool>(nullable: false),
                    VraagId = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    AanvullingId = table.Column<string>(nullable: true),
                    CompetentieProfielId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competentie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competentie_Aanvulling_AanvullingId",
                        column: x => x.AanvullingId,
                        principalTable: "Aanvulling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competentie_CompetentieProfiel_CompetentieProfielId",
                        column: x => x.CompetentieProfielId,
                        principalTable: "CompetentieProfiel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competentie_Vraag_VraagId",
                        column: x => x.VraagId,
                        principalTable: "Vraag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competentie_AanvullingId",
                table: "Competentie",
                column: "AanvullingId");

            migrationBuilder.CreateIndex(
                name: "IX_Competentie_CompetentieProfielId",
                table: "Competentie",
                column: "CompetentieProfielId");

            migrationBuilder.CreateIndex(
                name: "IX_Competentie_VraagId",
                table: "Competentie",
                column: "VraagId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacature_ProfielId",
                table: "Vacature",
                column: "ProfielId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competentie");

            migrationBuilder.DropTable(
                name: "Vacature");

            migrationBuilder.DropTable(
                name: "Aanvulling");

            migrationBuilder.DropTable(
                name: "Vraag");

            migrationBuilder.DropTable(
                name: "CompetentieProfiel");
        }
    }
}
