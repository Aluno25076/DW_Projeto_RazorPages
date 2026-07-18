using Microsoft.EntityFrameworkCore.Migrations;
using DW_Projeto_RazorPages.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Program",
                table: "Subscriptions",
                newName: "SubscriptProgram");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptProgram",
                table: "Subscriptions",
                newName: "Program");
        }
    }
}
