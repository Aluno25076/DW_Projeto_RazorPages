using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesAndRemoveDuplicatedOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "AppUsers",
                newName: "MemberNumber");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentStatus",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncNum",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "AppUsers",
                type: "decimal(8,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentStatus",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "FuncNum",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "MemberNumber",
                table: "AppUsers",
                newName: "MemberId");
        }
    }
}
