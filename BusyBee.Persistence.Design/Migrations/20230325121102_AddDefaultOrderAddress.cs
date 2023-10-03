using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultOrderAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTemplates",
                column: "Id",
                values: new object[]
                {
                    new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"),
                    new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8")
                });

            migrationBuilder.InsertData(
                table: "DataTemplateItems",
                columns: new[] { "Id", "DataTemplateId", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("67983a4e-3469-4050-a89e-b61ce22764cb"), new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"), "Адрес", 0 },
                    { new Guid("769a85a8-abad-4a2c-9e63-d5b9a804c873"), new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"), "От", 0 },
                    { new Guid("f604a88f-e9fe-49da-aa5f-338ab5f6963c"), new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"), "До", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("67983a4e-3469-4050-a89e-b61ce22764cb"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("769a85a8-abad-4a2c-9e63-d5b9a804c873"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("f604a88f-e9fe-49da-aa5f-338ab5f6963c"));

            migrationBuilder.DeleteData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"));

            migrationBuilder.DeleteData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"));
        }
    }
}
