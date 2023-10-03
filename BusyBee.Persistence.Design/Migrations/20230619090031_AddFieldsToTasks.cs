using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignToId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Tasks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignToId",
                table: "Tasks",
                column: "AssignToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_AssignToId",
                table: "Tasks",
                column: "AssignToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_AssignToId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignToId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AssignToId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tasks");
        }
    }
}
