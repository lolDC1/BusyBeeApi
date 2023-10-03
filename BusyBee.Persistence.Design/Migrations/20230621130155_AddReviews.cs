using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_City_CityId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_AssignToId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_User_City_CityId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPortfolioFile_User_CreatedBy",
                table: "UserPortfolioFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPortfolioFile",
                table: "UserPortfolioFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "UserPortfolioFile",
                newName: "UserPortfolioFiles");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_UserPortfolioFile_CreatedBy",
                table: "UserPortfolioFiles",
                newName: "IX_UserPortfolioFiles_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_User_CityId",
                table: "Users",
                newName: "IX_Users_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPortfolioFiles",
                table: "UserPortfolioFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    QualityOfWork = table.Column<int>(type: "integer", nullable: false),
                    Politeness = table.Column<int>(type: "integer", nullable: false),
                    Punctuality = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TaskId",
                table: "Reviews",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cities_CityId",
                table: "Tasks",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssignToId",
                table: "Tasks",
                column: "AssignToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreatedBy",
                table: "Tasks",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPortfolioFiles_Users_CreatedBy",
                table: "UserPortfolioFiles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cities_CityId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssignToId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPortfolioFiles_Users_CreatedBy",
                table: "UserPortfolioFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPortfolioFiles",
                table: "UserPortfolioFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserPortfolioFiles",
                newName: "UserPortfolioFile");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CityId",
                table: "User",
                newName: "IX_User_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPortfolioFiles_CreatedBy",
                table: "UserPortfolioFile",
                newName: "IX_UserPortfolioFile_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPortfolioFile",
                table: "UserPortfolioFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_City_CityId",
                table: "Tasks",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_AssignToId",
                table: "Tasks",
                column: "AssignToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_CreatedBy",
                table: "Tasks",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_City_CityId",
                table: "User",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPortfolioFile_User_CreatedBy",
                table: "UserPortfolioFile",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
