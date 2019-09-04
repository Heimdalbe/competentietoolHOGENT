using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class Vragen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VraagId",
                table: "Competenties",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Geboorteplaats",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

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
                name: "IVraag",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VraagStelling = table.Column<string>(nullable: true),
                    CompetentieId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    VignetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IVraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IVraag_Vignet_VignetId",
                        column: x => x.VignetId,
                        principalTable: "Vignet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mogelijkheid",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    VraagCasusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mogelijkheid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mogelijkheid_IVraag_VraagCasusId",
                        column: x => x.VraagCasusId,
                        principalTable: "IVraag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competenties_VraagId",
                table: "Competenties",
                column: "VraagId",
                unique: true,
                filter: "[VraagId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IVraag_VignetId",
                table: "IVraag",
                column: "VignetId");

            migrationBuilder.CreateIndex(
                name: "IX_Mogelijkheid_VraagCasusId",
                table: "Mogelijkheid",
                column: "VraagCasusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_IVraag_VraagId",
                table: "Competenties",
                column: "VraagId",
                principalTable: "IVraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_IVraag_VraagId",
                table: "Competenties");

            migrationBuilder.DropTable(
                name: "Mogelijkheid");

            migrationBuilder.DropTable(
                name: "IVraag");

            migrationBuilder.DropTable(
                name: "Vignet");

            migrationBuilder.DropIndex(
                name: "IX_Competenties_VraagId",
                table: "Competenties");

            migrationBuilder.DropColumn(
                name: "VraagId",
                table: "Competenties");

            migrationBuilder.AlterColumn<string>(
                name: "Geboorteplaats",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
