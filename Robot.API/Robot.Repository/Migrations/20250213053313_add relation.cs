using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Robot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RobotTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RobotTasks_UserId",
                table: "RobotTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User",
                table: "RobotTasks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User",
                table: "RobotTasks");

            migrationBuilder.DropIndex(
                name: "IX_RobotTasks_UserId",
                table: "RobotTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RobotTasks");
        }
    }
}
