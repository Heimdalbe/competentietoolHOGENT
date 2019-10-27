using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class OutputQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptieKeuze",
                table: "Response",
                newName: "OptieKeuzeId");

            migrationBuilder.RenameColumn(
                name: "Beschrijving",
                table: "Mogelijkheid",
                newName: "Output");

            migrationBuilder.AlterColumn<string>(
                name: "OptieKeuzeId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "Mogelijkheid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutputString",
                table: "IVraag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_OptieKeuzeId",
                table: "Response",
                column: "OptieKeuzeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                table: "Response",
                column: "OptieKeuzeId",
                principalTable: "Mogelijkheid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_OptieKeuzeId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "Input",
                table: "Mogelijkheid");

            migrationBuilder.DropColumn(
                name: "OutputString",
                table: "IVraag");

            migrationBuilder.RenameColumn(
                name: "OptieKeuzeId",
                table: "Response",
                newName: "OptieKeuze");

            migrationBuilder.RenameColumn(
                name: "Output",
                table: "Mogelijkheid",
                newName: "Beschrijving");

            migrationBuilder.AlterColumn<string>(
                name: "OptieKeuze",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
