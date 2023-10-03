using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditInTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Tasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DataTemplateItems",
                columns: new[] { "Id", "DataTemplateId", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("0d6701ca-8e30-4105-a9f8-6485b02eaffa"), new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"), "От", 0 },
                    { new Guid("1f7dcab2-0c35-47c5-b433-f2334c1ede08"), new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"), "До", 0 },
                    { new Guid("90883a11-4a54-4c3e-b574-4b1d033c391d"), new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"), "Адрес", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("0d6701ca-8e30-4105-a9f8-6485b02eaffa"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("1f7dcab2-0c35-47c5-b433-f2334c1ede08"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("90883a11-4a54-4c3e-b574-4b1d033c391d"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tasks");

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
    }
}
