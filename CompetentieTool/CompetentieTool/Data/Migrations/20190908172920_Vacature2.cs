using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class Vacature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competentie_CompetentieProfiel_CompetentieProfielId",
                table: "Competentie");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacature_CompetentieProfiel_ProfielId",
                table: "Vacature");

            migrationBuilder.DropTable(
                name: "CompetentieProfiel");

            migrationBuilder.DropIndex(
                name: "IX_Vacature_ProfielId",
                table: "Vacature");

            migrationBuilder.DropIndex(
                name: "IX_Competentie_CompetentieProfielId",
                table: "Competentie");

            migrationBuilder.DropColumn(
                name: "ProfielId",
                table: "Vacature");

            migrationBuilder.DropColumn(
                name: "CompetentieProfielId",
                table: "Competentie");

            migrationBuilder.CreateTable(
                name: "VacatureCompetentie",
                columns: table => new
                {
                    VacatureId = table.Column<string>(nullable: false),
                    CompetentieId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacatureCompetentie", x => new { x.VacatureId, x.CompetentieId });
                    table.ForeignKey(
                        name: "FK_VacatureCompetentie_Competentie_CompetentieId",
                        column: x => x.CompetentieId,
                        principalTable: "Competentie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacatureCompetentie_Vacature_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "Vacature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacatureCompetentie_CompetentieId",
                table: "VacatureCompetentie",
                column: "CompetentieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacatureCompetentie");

            migrationBuilder.AddColumn<string>(
                name: "ProfielId",
                table: "Vacature",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompetentieProfielId",
                table: "Competentie",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vacature_ProfielId",
                table: "Vacature",
                column: "ProfielId");

            migrationBuilder.CreateIndex(
                name: "IX_Competentie_CompetentieProfielId",
                table: "Competentie",
                column: "CompetentieProfielId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competentie_CompetentieProfiel_CompetentieProfielId",
                table: "Competentie",
                column: "CompetentieProfielId",
                principalTable: "CompetentieProfiel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacature_CompetentieProfiel_ProfielId",
                table: "Vacature",
                column: "ProfielId",
                principalTable: "CompetentieProfiel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
