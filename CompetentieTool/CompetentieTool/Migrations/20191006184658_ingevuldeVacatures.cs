using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class ingevuldeVacatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OptieKeuze = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngevuldeVacatures_VacatureId",
                table: "IngevuldeVacatures",
                column: "VacatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_IngevuldeVacatureId",
                table: "Response",
                column: "IngevuldeVacatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "IngevuldeVacatures");
        }
    }
}
