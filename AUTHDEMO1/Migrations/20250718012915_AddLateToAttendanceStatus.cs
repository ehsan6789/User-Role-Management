using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTHDEMO1.Migrations
{
    /// <inheritdoc />
    public partial class AddLateToAttendanceStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAssignments_AspNetUsers_AssignedToUserId",
                table: "AssetAssignments");

            migrationBuilder.DropIndex(
                name: "IX_AssetAssignments_AssignedToUserId",
                table: "AssetAssignments");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "AssetAssignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId",
                table: "AssetAssignments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAssignments_AssignedToUserId",
                table: "AssetAssignments",
                column: "AssignedToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAssignments_AspNetUsers_AssignedToUserId",
                table: "AssetAssignments",
                column: "AssignedToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
