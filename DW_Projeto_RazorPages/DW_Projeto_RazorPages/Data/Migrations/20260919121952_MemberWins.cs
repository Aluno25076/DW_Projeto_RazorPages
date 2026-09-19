using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemberWins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_MatchResult_MatchResultResultId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_MatchResultResultId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "MatchResultResultId",
                table: "AppUsers");

            migrationBuilder.CreateTable(
                name: "MatchResultMember",
                columns: table => new
                {
                    WiennersId = table.Column<int>(type: "int", nullable: false),
                    WinsResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResultMember", x => new { x.WiennersId, x.WinsResultId });
                    table.ForeignKey(
                        name: "FK_MatchResultMember_AppUsers_WiennersId",
                        column: x => x.WiennersId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchResultMember_MatchResult_WinsResultId",
                        column: x => x.WinsResultId,
                        principalTable: "MatchResult",
                        principalColumn: "ResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchResultMember_WinsResultId",
                table: "MatchResultMember",
                column: "WinsResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchResultMember");

            migrationBuilder.AddColumn<int>(
                name: "MatchResultResultId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_MatchResultResultId",
                table: "AppUsers",
                column: "MatchResultResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_MatchResult_MatchResultResultId",
                table: "AppUsers",
                column: "MatchResultResultId",
                principalTable: "MatchResult",
                principalColumn: "ResultId");
        }
    }
}
