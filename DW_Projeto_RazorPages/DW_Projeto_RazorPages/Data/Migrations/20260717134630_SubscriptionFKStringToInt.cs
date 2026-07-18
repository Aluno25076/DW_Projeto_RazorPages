using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionFKStringToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionFK",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubscriptionFK",
                table: "AppUsers",
                column: "SubscriptionFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionFK",
                table: "AppUsers",
                column: "SubscriptionFK",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionFK",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_SubscriptionFK",
                table: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionFK",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
