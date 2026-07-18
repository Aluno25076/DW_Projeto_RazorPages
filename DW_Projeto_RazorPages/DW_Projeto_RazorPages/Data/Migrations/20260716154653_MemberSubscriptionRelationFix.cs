using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemberSubscriptionRelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.RenameColumn(
                name: "SubscribedFK",
                table: "AppUsers",
                newName: "SubscriptionFK");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "SubscriptionFK",
                table: "AppUsers",
                newName: "SubscribedFK");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    MemberFK = table.Column<int>(type: "int", nullable: false),
                    SubscriptionFK = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => new { x.MemberFK, x.SubscriptionFK });
                    table.ForeignKey(
                        name: "FK_Subscribers_AppUsers_MemberFK",
                        column: x => x.MemberFK,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscribers_Subscriptions_SubscriptionFK",
                        column: x => x.SubscriptionFK,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_SubscriptionFK",
                table: "Subscribers",
                column: "SubscriptionFK");
        }
    }
}
