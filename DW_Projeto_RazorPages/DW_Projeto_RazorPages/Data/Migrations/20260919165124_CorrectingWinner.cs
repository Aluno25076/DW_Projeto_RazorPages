using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResultMember_AppUsers_WiennersId",
                table: "MatchResultMember");

            migrationBuilder.RenameColumn(
                name: "WiennersId",
                table: "MatchResultMember",
                newName: "WinnersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResultMember_AppUsers_WinnersId",
                table: "MatchResultMember",
                column: "WinnersId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchResultMember_AppUsers_WinnersId",
                table: "MatchResultMember");

            migrationBuilder.RenameColumn(
                name: "WinnersId",
                table: "MatchResultMember",
                newName: "WiennersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchResultMember_AppUsers_WiennersId",
                table: "MatchResultMember",
                column: "WiennersId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
