using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTHDEMO1.Migrations
{
    /// <inheritdoc />
    public partial class AssignedToUserIdTypeChange : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserId",
                table: "AssetAssignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAssignments_AspNetUsers_AssignedToUserId1",
                table: "AssetAssignments");

            migrationBuilder.DropIndex(
                name: "IX_AssetAssignments_AssignedToUserId1",
                table: "AssetAssignments");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId1",
                table: "AssetAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToUserId",
                table: "AssetAssignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
