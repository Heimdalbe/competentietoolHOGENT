using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class Vacature3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competentie_Aanvulling_AanvullingId",
                table: "Competentie");

            migrationBuilder.DropForeignKey(
                name: "FK_Competentie_Vraag_VraagId",
                table: "Competentie");

            migrationBuilder.DropForeignKey(
                name: "FK_VacatureCompetentie_Competentie_CompetentieId",
                table: "VacatureCompetentie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competentie",
                table: "Competentie");

            migrationBuilder.RenameTable(
                name: "Competentie",
                newName: "Competenties");

            migrationBuilder.RenameIndex(
                name: "IX_Competentie_VraagId",
                table: "Competenties",
                newName: "IX_Competenties_VraagId");

            migrationBuilder.RenameIndex(
                name: "IX_Competentie_AanvullingId",
                table: "Competenties",
                newName: "IX_Competenties_AanvullingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competenties",
                table: "Competenties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_Aanvulling_AanvullingId",
                table: "Competenties",
                column: "AanvullingId",
                principalTable: "Aanvulling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_Vraag_VraagId",
                table: "Competenties",
                column: "VraagId",
                principalTable: "Vraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacatureCompetentie_Competenties_CompetentieId",
                table: "VacatureCompetentie",
                column: "CompetentieId",
                principalTable: "Competenties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_Aanvulling_AanvullingId",
                table: "Competenties");

            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_Vraag_VraagId",
                table: "Competenties");

            migrationBuilder.DropForeignKey(
                name: "FK_VacatureCompetentie_Competenties_CompetentieId",
                table: "VacatureCompetentie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competenties",
                table: "Competenties");

            migrationBuilder.RenameTable(
                name: "Competenties",
                newName: "Competentie");

            migrationBuilder.RenameIndex(
                name: "IX_Competenties_VraagId",
                table: "Competentie",
                newName: "IX_Competentie_VraagId");

            migrationBuilder.RenameIndex(
                name: "IX_Competenties_AanvullingId",
                table: "Competentie",
                newName: "IX_Competentie_AanvullingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competentie",
                table: "Competentie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competentie_Aanvulling_AanvullingId",
                table: "Competentie",
                column: "AanvullingId",
                principalTable: "Aanvulling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competentie_Vraag_VraagId",
                table: "Competentie",
                column: "VraagId",
                principalTable: "Vraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacatureCompetentie_Competentie_CompetentieId",
                table: "VacatureCompetentie",
                column: "CompetentieId",
                principalTable: "Competentie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
