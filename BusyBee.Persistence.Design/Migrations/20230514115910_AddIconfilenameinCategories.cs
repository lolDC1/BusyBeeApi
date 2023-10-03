using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddIconfilenameinCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconFilename",
                table: "CategoriesOfTasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconFilename",
                table: "CategoriesOfCategories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconFilename",
                table: "CategoriesOfTasks");

            migrationBuilder.DropColumn(
                name: "IconFilename",
                table: "CategoriesOfCategories");
        }
    }
}
