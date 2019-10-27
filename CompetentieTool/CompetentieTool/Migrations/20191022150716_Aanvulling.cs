using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class Aanvulling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AanvullingId",
                table: "Competenties",
                nullable: true);

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
                name: "AanvulOptie",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    IsSchrapOptie = table.Column<bool>(nullable: false),
                    AanvullingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AanvulOptie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AanvulOptie_Aanvulling_AanvullingId",
                        column: x => x.AanvullingId,
                        principalTable: "Aanvulling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competenties_AanvullingId",
                table: "Competenties",
                column: "AanvullingId");

            migrationBuilder.CreateIndex(
                name: "IX_AanvulOptie_AanvullingId",
                table: "AanvulOptie",
                column: "AanvullingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_Aanvulling_AanvullingId",
                table: "Competenties",
                column: "AanvullingId",
                principalTable: "Aanvulling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_Aanvulling_AanvullingId",
                table: "Competenties");

            migrationBuilder.DropTable(
                name: "AanvulOptie");

            migrationBuilder.DropTable(
                name: "Aanvulling");

            migrationBuilder.DropIndex(
                name: "IX_Competenties_AanvullingId",
                table: "Competenties");

            migrationBuilder.DropColumn(
                name: "AanvullingId",
                table: "Competenties");
        }
    }
}
