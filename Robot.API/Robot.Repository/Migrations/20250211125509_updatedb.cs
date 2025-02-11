using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Robot.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_TaskID",
                table: "Log");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Stamp",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Robot",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Operators",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Maintenance",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Log",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RobotTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RobotID = table.Column<int>(type: "integer", nullable: false),
                    StampID = table.Column<int>(type: "integer", nullable: true),
                    ProductID = table.Column<int>(type: "integer", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Tasks_Robot",
                        column: x => x.RobotID,
                        principalTable: "Robot",
                        principalColumn: "RobotID");
                    table.ForeignKey(
                        name: "FK_Tasks_Stamp",
                        column: x => x.StampID,
                        principalTable: "Stamp",
                        principalColumn: "StampID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RobotTasks_ProductID",
                table: "RobotTasks",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_RobotTasks_RobotID",
                table: "RobotTasks",
                column: "RobotID");

            migrationBuilder.CreateIndex(
                name: "IX_RobotTasks_StampID",
                table: "RobotTasks",
                column: "StampID");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_TaskID",
                table: "Log",
                column: "TaskID",
                principalTable: "RobotTasks",
                principalColumn: "TaskID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_TaskID",
                table: "Log");

            migrationBuilder.DropTable(
                name: "RobotTasks");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Stamp");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Log");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: true),
                    RobotID = table.Column<int>(type: "integer", nullable: false),
                    StampID = table.Column<int>(type: "integer", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Tasks_Robot",
                        column: x => x.RobotID,
                        principalTable: "Robot",
                        principalColumn: "RobotID");
                    table.ForeignKey(
                        name: "FK_Tasks_Stamp",
                        column: x => x.StampID,
                        principalTable: "Stamp",
                        principalColumn: "StampID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProductID",
                table: "Tasks",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RobotID",
                table: "Tasks",
                column: "RobotID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StampID",
                table: "Tasks",
                column: "StampID");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_TaskID",
                table: "Log",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "TaskID");
        }
    }
}
