using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AppUsers");
        }
    }
}
