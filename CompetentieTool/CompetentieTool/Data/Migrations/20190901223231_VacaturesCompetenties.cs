using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class VacaturesCompetenties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Straat",
                table: "AspNetUsers",
                newName: "Nationaliteit");

            migrationBuilder.RenameColumn(
                name: "Stad",
                table: "AspNetUsers",
                newName: "Gsm");

            migrationBuilder.RenameColumn(
                name: "Land",
                table: "AspNetUsers",
                newName: "Geslacht");

            migrationBuilder.AlterColumn<int>(
                name: "Postcode",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Geboorteplaats",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GebruikersID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gemeente",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Competenties",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Verklaring = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competenties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Functie = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacatureCompetenties",
                columns: table => new
                {
                    VacatureId = table.Column<string>(nullable: false),
                    CompetentieId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacatureCompetenties", x => new { x.VacatureId, x.CompetentieId });
                    table.ForeignKey(
                        name: "FK_VacatureCompetenties_Competenties_CompetentieId",
                        column: x => x.CompetentieId,
                        principalTable: "Competenties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacatureCompetenties_Vacatures_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "Vacatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacatureCompetenties_CompetentieId",
                table: "VacatureCompetenties",
                column: "CompetentieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacatureCompetenties");

            migrationBuilder.DropTable(
                name: "Competenties");

            migrationBuilder.DropTable(
                name: "Vacatures");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Geboorteplaats",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GebruikersID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gemeente",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Nationaliteit",
                table: "AspNetUsers",
                newName: "Straat");

            migrationBuilder.RenameColumn(
                name: "Gsm",
                table: "AspNetUsers",
                newName: "Stad");

            migrationBuilder.RenameColumn(
                name: "Geslacht",
                table: "AspNetUsers",
                newName: "Land");

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
