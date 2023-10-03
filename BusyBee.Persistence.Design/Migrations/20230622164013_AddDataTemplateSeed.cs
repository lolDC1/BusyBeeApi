using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTemplateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTemplates",
                columns: new[] { "Id", "EstimatedCost" },
                values: new object[] { new Guid("469609a2-2435-4bdc-938a-ba2441f8d72a"), 460.0 });

            migrationBuilder.InsertData(
                table: "CategoriesOfTasks",
                columns: new[] { "Id", "IconFilename", "OrderAddressDataTemplateId", "ParentId", "PaymentDataTemplateId", "Title" },
                values: new object[] { new Guid("9f979a5f-2c4d-4d84-8d56-c09dea3e286e"), null, new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"), new Guid("ba194614-fdc8-4830-bde0-647532e7da46"), new Guid("469609a2-2435-4bdc-938a-ba2441f8d72a"), "Прибирання квартир" });

            migrationBuilder.InsertData(
                table: "DataTemplateItems",
                columns: new[] { "Id", "DataTemplateId", "Title", "Type" },
                values: new object[] { new Guid("9449e87d-3556-462b-8f74-6ba125042930"), new Guid("469609a2-2435-4bdc-938a-ba2441f8d72a"), "", 2 });

            migrationBuilder.InsertData(
                table: "DataTemplateItemValues",
                columns: new[] { "Id", "AddedMoney", "DataTemplateItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("4d7b8671-51e9-4206-bf07-956d5572fcfb"), 400, new Guid("9449e87d-3556-462b-8f74-6ba125042930"), "Мийка вікон" },
                    { new Guid("6260925c-306c-40b0-a1f6-04abf762d861"), 200, new Guid("9449e87d-3556-462b-8f74-6ba125042930"), "Мийка санвузла" },
                    { new Guid("c89187d6-2b98-49d2-b873-1d4dddac3488"), 200, new Guid("9449e87d-3556-462b-8f74-6ba125042930"), "Мийка холодильника" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesOfTasks",
                keyColumn: "Id",
                keyValue: new Guid("9f979a5f-2c4d-4d84-8d56-c09dea3e286e"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("4d7b8671-51e9-4206-bf07-956d5572fcfb"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("6260925c-306c-40b0-a1f6-04abf762d861"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("c89187d6-2b98-49d2-b873-1d4dddac3488"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("9449e87d-3556-462b-8f74-6ba125042930"));

            migrationBuilder.DeleteData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("469609a2-2435-4bdc-938a-ba2441f8d72a"));
        }
    }
}
