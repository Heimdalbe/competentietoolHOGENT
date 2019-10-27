using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class ResponseObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vraag",
                table: "Response");

            migrationBuilder.AlterColumn<string>(
                name: "VraagId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Response_VraagId",
                table: "Response",
                column: "VraagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                table: "Response",
                column: "OptieKeuzeId",
                principalTable: "Mogelijkheid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Vragen_VraagId",
                table: "Response",
                column: "VraagId",
                principalTable: "Vragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Mogelijkheid_OptieKeuzeId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Vragen_VraagId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_OptieKeuzeId",
                table: "Response");

            migrationBuilder.DropIndex(
                name: "IX_Response_VraagId",
                table: "Response");

            migrationBuilder.AlterColumn<string>(
                name: "VraagId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OptieKeuzeId",
                table: "Response",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vraag",
                table: "Response",
                nullable: true);
        }
    }
}
