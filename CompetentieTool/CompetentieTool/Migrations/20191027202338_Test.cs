using Microsoft.EntityFrameworkCore.Migrations;

namespace CompetentieTool.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_IVraag_VraagId",
                table: "Competenties");

            migrationBuilder.DropForeignKey(
                name: "FK_IVraag_Vignet_VignetId",
                table: "IVraag");

            migrationBuilder.DropForeignKey(
                name: "FK_Mogelijkheid_IVraag_VraagCasusId",
                table: "Mogelijkheid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IVraag",
                table: "IVraag");

            migrationBuilder.RenameTable(
                name: "IVraag",
                newName: "Vragen");

            migrationBuilder.RenameIndex(
                name: "IX_IVraag_VignetId",
                table: "Vragen",
                newName: "IX_Vragen_VignetId");

            migrationBuilder.AddColumn<string>(
                name: "Vraag",
                table: "Response",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vragen",
                table: "Vragen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_Vragen_VraagId",
                table: "Competenties",
                column: "VraagId",
                principalTable: "Vragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mogelijkheid_Vragen_VraagCasusId",
                table: "Mogelijkheid",
                column: "VraagCasusId",
                principalTable: "Vragen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vragen_Vignet_VignetId",
                table: "Vragen",
                column: "VignetId",
                principalTable: "Vignet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competenties_Vragen_VraagId",
                table: "Competenties");

            migrationBuilder.DropForeignKey(
                name: "FK_Mogelijkheid_Vragen_VraagCasusId",
                table: "Mogelijkheid");

            migrationBuilder.DropForeignKey(
                name: "FK_Vragen_Vignet_VignetId",
                table: "Vragen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vragen",
                table: "Vragen");

            migrationBuilder.DropColumn(
                name: "Vraag",
                table: "Response");

            migrationBuilder.RenameTable(
                name: "Vragen",
                newName: "IVraag");

            migrationBuilder.RenameIndex(
                name: "IX_Vragen_VignetId",
                table: "IVraag",
                newName: "IX_IVraag_VignetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IVraag",
                table: "IVraag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competenties_IVraag_VraagId",
                table: "Competenties",
                column: "VraagId",
                principalTable: "IVraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IVraag_Vignet_VignetId",
                table: "IVraag",
                column: "VignetId",
                principalTable: "Vignet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mogelijkheid_IVraag_VraagCasusId",
                table: "Mogelijkheid",
                column: "VraagCasusId",
                principalTable: "IVraag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
