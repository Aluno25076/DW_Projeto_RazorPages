using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class FieldFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Fields_FieldId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "Matches",
                newName: "FieldFK");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FieldId",
                table: "Matches",
                newName: "IX_Matches_FieldFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Fields_FieldFK",
                table: "Matches",
                column: "FieldFK",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Fields_FieldFK",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "FieldFK",
                table: "Matches",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_FieldFK",
                table: "Matches",
                newName: "IX_Matches_FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Fields_FieldId",
                table: "Matches",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
