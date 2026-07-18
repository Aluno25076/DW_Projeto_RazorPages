using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "MatchParticipants");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AppUsers");

            migrationBuilder.CreateTable(
                name: "MatchMember",
                columns: table => new
                {
                    MatchesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMember", x => new { x.MatchesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_MatchMember_AppUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchMember_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchMember_ParticipantsId",
                table: "MatchMember",
                column: "ParticipantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchMember");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchParticipants",
                columns: table => new
                {
                    MemberFK = table.Column<int>(type: "int", nullable: false),
                    MatchFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchParticipants", x => new { x.MemberFK, x.MatchFK });
                    table.ForeignKey(
                        name: "FK_MatchParticipants_AppUsers_MemberFK",
                        column: x => x.MemberFK,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchParticipants_Matches_MatchFK",
                        column: x => x.MatchFK,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchParticipants_MatchFK",
                table: "MatchParticipants",
                column: "MatchFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
