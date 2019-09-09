using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Data.Migrations
{
    public partial class _20190412094041 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");

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

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Emailadres",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Emailadres",
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

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AspNetUsers",
                newName: "UserName");

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
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
