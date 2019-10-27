using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class Aanvullingen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_OptieKeuzeId",
                table: "Response");

            migrationBuilder.AlterColumn<string>(
                name: "OptieKeuzeId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aanvulling",
                table: "Mogelijkheid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aanvulling",
                table: "Mogelijkheid");

            migrationBuilder.AlterColumn<string>(
                name: "OptieKeuzeId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
