using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataCategoriesOfTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTemplates",
                columns: new[] { "Id", "EstimatedCost" },
                values: new object[,]
                {
                    { new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"), 400.0 },
                    { new Guid("e8d111b8-21a3-445f-a090-cc07dbdad3a3"), 700.0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesOfTasks",
                columns: new[] { "Id", "IconFilename", "OrderAddressDataTemplateId", "ParentId", "PaymentDataTemplateId", "Title" },
                values: new object[,]
                {
                    { new Guid("6782b015-0aed-4bfa-a773-54984ce407e8"), null, new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"), new Guid("ef5ed6a2-3fda-4307-97a5-e6600d8e1c52"), new Guid("e8d111b8-21a3-445f-a090-cc07dbdad3a3"), "Столяр" },
                    { new Guid("edae1870-34c2-4663-ae76-a1e8bc749ffd"), null, new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"), new Guid("2d2dc17a-abfd-4e1c-ab88-b8dc7e72dfe8"), new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"), "Вантажні перевезення" }
                });

            migrationBuilder.InsertData(
                table: "DataTemplateItems",
                columns: new[] { "Id", "DataTemplateId", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"), new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"), "Вантажники", 1 },
                    { new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"), new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"), "Тип авто", 1 },
                    { new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"), new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"), "Наявність робочого ліфта", 1 }
                });

            migrationBuilder.InsertData(
                table: "DataTemplateItemValues",
                columns: new[] { "Id", "AddedMoney", "DataTemplateItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0ad8cac6-b5bd-43b8-a066-e33b654d49de"), 2000, new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"), "КАМАЗ (до 13 тонн)" },
                    { new Guid("27ebadb1-8fa4-4a5d-94fb-b7e40a89c2cb"), 400, new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"), "немає ліфта (1-5 поверх)" },
                    { new Guid("3239d382-7026-467c-84eb-d4cc8c4d8264"), 600, new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"), "немає ліфта (5+ поверхів)" },
                    { new Guid("606637ac-7dea-4b70-bcdc-6439637d9e3c"), 0, new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"), "є пасажирський" },
                    { new Guid("60cf5c19-1b01-4b78-be95-48f2493c2371"), 1000, new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"), "ЗІЛ (до 5.5 тонн)" },
                    { new Guid("7646766d-68c2-4619-9572-26bd2fe3682e"), 0, new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"), "є вантажний" },
                    { new Guid("90ee4ec2-3651-47dd-ab89-57fefc2203b8"), 0, new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"), "не потрібні" },
                    { new Guid("920db9c4-7ca3-4fd7-a624-6fa561c8c8fe"), 100, new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"), "Газель (до 1.5 тонн)" },
                    { new Guid("9a6e37a4-f4d2-420a-b2cc-75eb179e19dc"), 200, new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"), "1 вантажник" },
                    { new Guid("a54bc5b6-1a5e-48fd-aca8-2dd306bc8237"), 600, new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"), "3 вантажника" },
                    { new Guid("c83a6ca6-68e0-4928-914c-7d530da72164"), 0, new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"), "Мікроавтобус (до 2 тонн)" },
                    { new Guid("d3e9cdb3-6b52-4b3a-9529-dfd245036684"), 400, new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"), "2 вантажника" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesOfTasks",
                keyColumn: "Id",
                keyValue: new Guid("6782b015-0aed-4bfa-a773-54984ce407e8"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfTasks",
                keyColumn: "Id",
                keyValue: new Guid("edae1870-34c2-4663-ae76-a1e8bc749ffd"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("0ad8cac6-b5bd-43b8-a066-e33b654d49de"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("27ebadb1-8fa4-4a5d-94fb-b7e40a89c2cb"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("3239d382-7026-467c-84eb-d4cc8c4d8264"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("606637ac-7dea-4b70-bcdc-6439637d9e3c"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("60cf5c19-1b01-4b78-be95-48f2493c2371"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("7646766d-68c2-4619-9572-26bd2fe3682e"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("90ee4ec2-3651-47dd-ab89-57fefc2203b8"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("920db9c4-7ca3-4fd7-a624-6fa561c8c8fe"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("9a6e37a4-f4d2-420a-b2cc-75eb179e19dc"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("a54bc5b6-1a5e-48fd-aca8-2dd306bc8237"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("c83a6ca6-68e0-4928-914c-7d530da72164"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItemValues",
                keyColumn: "Id",
                keyValue: new Guid("d3e9cdb3-6b52-4b3a-9529-dfd245036684"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("2316a1b8-87aa-43f8-9ad0-76142f670218"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("ca3b3bf7-da39-429a-aa96-2e30e661edb8"));

            migrationBuilder.DeleteData(
                table: "DataTemplateItems",
                keyColumn: "Id",
                keyValue: new Guid("efd1f2bd-ab09-4c95-a9af-ecffb2f9f8d0"));

            migrationBuilder.DeleteData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e8d111b8-21a3-445f-a090-cc07dbdad3a3"));

            migrationBuilder.DeleteData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("df91e5af-5663-420d-aa49-3c3b7e41f6a0"));
        }
    }
}
