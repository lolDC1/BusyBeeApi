using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPortfolioFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPortfolioFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "text", nullable: false),
                    OriginalName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPortfolioFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPortfolioFile_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPortfolioFile_CreatedBy",
                table: "UserPortfolioFile",
                column: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPortfolioFile");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "User");
        }
    }
}
