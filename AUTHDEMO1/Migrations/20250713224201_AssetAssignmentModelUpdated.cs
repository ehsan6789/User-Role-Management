using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTHDEMO1.Migrations
{
    /// <inheritdoc />
    public partial class AssetAssignmentModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAssignments_AspNetUsers_AssignedToUserId1",
                table: "AssetAssignments");

            migrationBuilder.DropIndex(
                name: "IX_AssetAssignments_AssignedToUserId1",
                table: "AssetAssignments");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "AssetAssignments");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId1",
                table: "AssetAssignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToUserId",
                table: "AssetAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId1",
                table: "AssetAssignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetAssignments_AssignedToUserId1",
                table: "AssetAssignments",
                column: "AssignedToUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAssignments_AspNetUsers_AssignedToUserId1",
                table: "AssetAssignments",
                column: "AssignedToUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
