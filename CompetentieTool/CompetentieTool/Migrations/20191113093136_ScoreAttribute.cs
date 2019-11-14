using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class ScoreAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngevuldeVacatures_AspNetUsers_SollicitantId",
                table: "IngevuldeVacatures");

            migrationBuilder.DropIndex(
                name: "IX_IngevuldeVacatures_SollicitantId",
                table: "IngevuldeVacatures");

            migrationBuilder.DropColumn(
                name: "Opleiding",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Opleidingsniveau",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SollicitantId",
                table: "IngevuldeVacatures",
                newName: "VoornaamSollicitant");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Mogelijkheid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "VoornaamSollicitant",
                table: "IngevuldeVacatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AchternaamSollicitant",
                table: "IngevuldeVacatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailSollicitant",
                table: "IngevuldeVacatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoonSollicitant",
                table: "IngevuldeVacatures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Mogelijkheid");

            migrationBuilder.DropColumn(
                name: "AchternaamSollicitant",
                table: "IngevuldeVacatures");

            migrationBuilder.DropColumn(
                name: "EmailSollicitant",
                table: "IngevuldeVacatures");

            migrationBuilder.DropColumn(
                name: "TelefoonSollicitant",
                table: "IngevuldeVacatures");

            migrationBuilder.RenameColumn(
                name: "VoornaamSollicitant",
                table: "IngevuldeVacatures",
                newName: "SollicitantId");

            migrationBuilder.AlterColumn<string>(
                name: "SollicitantId",
                table: "IngevuldeVacatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opleiding",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Opleidingsniveau",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngevuldeVacatures_SollicitantId",
                table: "IngevuldeVacatures",
                column: "SollicitantId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngevuldeVacatures_AspNetUsers_SollicitantId",
                table: "IngevuldeVacatures",
                column: "SollicitantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
