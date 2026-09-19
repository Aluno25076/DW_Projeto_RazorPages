using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_RazorPages.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalaryAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmploymentStatus",
                table: "AppUsers",
                newName: "Status");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "AppUsers",
                type: "decimal(9,2)",
                precision: 9,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AppUsers",
                newName: "EmploymentStatus");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "AppUsers",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)",
                oldPrecision: 9,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
