using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class InternalResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Results_ResultId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.RenameColumn(
                name: "ResultId",
                table: "AppUsers",
                newName: "MatchResultResultId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ResultId",
                table: "AppUsers",
                newName: "IX_AppUsers_MatchResultResultId");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchResult",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResult", x => x.ResultId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ResultId",
                table: "Matches",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_MatchResult_MatchResultResultId",
                table: "AppUsers",
                column: "MatchResultResultId",
                principalTable: "MatchResult",
                principalColumn: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchResult_ResultId",
                table: "Matches",
                column: "ResultId",
                principalTable: "MatchResult",
                principalColumn: "ResultId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_MatchResult_MatchResultResultId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchResult_ResultId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "MatchResult");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ResultId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "MatchResultResultId",
                table: "AppUsers",
                newName: "ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_MatchResultResultId",
                table: "AppUsers",
                newName: "IX_AppUsers_ResultId");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Matches_MatchFK",
                        column: x => x.MatchFK,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_MatchFK",
                table: "Results",
                column: "MatchFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Results_ResultId",
                table: "AppUsers",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id");
        }
    }
}
