using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTHDEMO1.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnicianNameAndCostToMaintenanceRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "MaintenanceRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "MaintenanceRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "MaintenanceRecords");

            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "MaintenanceRecords");
        }
    }
}
