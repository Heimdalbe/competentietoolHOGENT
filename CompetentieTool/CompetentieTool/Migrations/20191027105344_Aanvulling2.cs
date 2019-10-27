using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class Aanvulling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeselecteerdeOptie",
                table: "VacatureCompetentie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeselecteerdeOptie",
                table: "VacatureCompetentie");
        }
    }
}
