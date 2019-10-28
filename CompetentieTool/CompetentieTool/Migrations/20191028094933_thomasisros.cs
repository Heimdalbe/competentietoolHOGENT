using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class thomasisros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AanvulOptie");

            migrationBuilder.AddColumn<string>(
                name: "AanvullingId",
                table: "Mogelijkheid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSchrapOptie",
                table: "Mogelijkheid",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Mogelijkheid_AanvullingId",
                table: "Mogelijkheid",
                column: "AanvullingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mogelijkheid_Aanvulling_AanvullingId",
                table: "Mogelijkheid",
                column: "AanvullingId",
                principalTable: "Aanvulling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mogelijkheid_Aanvulling_AanvullingId",
                table: "Mogelijkheid");

            migrationBuilder.DropIndex(
                name: "IX_Mogelijkheid_AanvullingId",
                table: "Mogelijkheid");

            migrationBuilder.DropColumn(
                name: "AanvullingId",
                table: "Mogelijkheid");

            migrationBuilder.DropColumn(
                name: "IsSchrapOptie",
                table: "Mogelijkheid");

            migrationBuilder.CreateTable(
                name: "AanvulOptie",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AanvullingId = table.Column<string>(nullable: true),
                    IsSchrapOptie = table.Column<bool>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "IX_AanvulOptie_AanvullingId",
                table: "AanvulOptie",
                column: "AanvullingId");
        }
    }
}
