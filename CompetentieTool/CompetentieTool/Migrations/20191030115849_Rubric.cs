using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class Rubric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VraagRubricsId",
                table: "Mogelijkheid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mogelijkheid_VraagRubricsId",
                table: "Mogelijkheid",
                column: "VraagRubricsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mogelijkheid_Vragen_VraagRubricsId",
                table: "Mogelijkheid",
                column: "VraagRubricsId",
                principalTable: "Vragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mogelijkheid_Vragen_VraagRubricsId",
                table: "Mogelijkheid");

            migrationBuilder.DropIndex(
                name: "IX_Mogelijkheid_VraagRubricsId",
                table: "Mogelijkheid");

            migrationBuilder.DropColumn(
                name: "VraagRubricsId",
                table: "Mogelijkheid");
        }
    }
}
