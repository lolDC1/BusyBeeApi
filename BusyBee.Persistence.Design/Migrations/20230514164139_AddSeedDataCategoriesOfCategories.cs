using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataCategoriesOfCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EstimatedCost",
                table: "DataTemplates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "CategoriesOfCategories",
                columns: new[] { "Id", "IconFilename", "ParentId", "Title" },
                values: new object[,]
                {
                    { new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "category_icon_dim.svg", null, "Дім" },
                    { new Guid("17ad73db-4fd7-4dd1-a26a-b049a69a1606"), "category_icon_vikladachi.svg", null, "Викладачі" },
                    { new Guid("443f7547-3a93-438b-b6d5-7f5cac0a3e13"), "category_icon_dostavka.svg", null, "Доставка" },
                    { new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), null, null, "Iнше" },
                    { new Guid("c9a09ee1-56b8-43f0-9f2a-51b1f05b8a3e"), "category_icon_bisnes.svg", null, "Бізнес" },
                    { new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"), "category_icon_frilans.svg", null, "Фріланс" }
                });

            migrationBuilder.UpdateData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7cfc38e6-97fc-41d6-a267-0e160c2d2fba"),
                column: "EstimatedCost",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "DataTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cd081f14-3b0d-4d49-9aea-d3cb1fe379d8"),
                column: "EstimatedCost",
                value: 0.0);

            migrationBuilder.InsertData(
                table: "CategoriesOfCategories",
                columns: new[] { "Id", "IconFilename", "ParentId", "Title" },
                values: new object[,]
                {
                    { new Guid("00b3cc7c-7f0e-4061-a7e7-eec8e8d98972"), "category_icon_rozrobka_saitiv_i_dodtkiv.svg", new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"), "Розробка сайтів та додатків" },
                    { new Guid("09696c51-d66a-4e9c-a830-ec4518419b1f"), "category_icon_robota_v_interneti.svg", new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"), "Робота в Інтернеті" },
                    { new Guid("0afc549d-c57c-48e5-aa35-de0000bb7179"), "category_icon_buro_perekladiv.svg", new Guid("17ad73db-4fd7-4dd1-a26a-b049a69a1606"), "Бюро перекладів" },
                    { new Guid("104dda7e-6050-4a3b-b58c-64ba8f77cd20"), "category_icon_poslugi_repetitoriv.svg", new Guid("17ad73db-4fd7-4dd1-a26a-b049a69a1606"), "Послуги репетиторів" },
                    { new Guid("1252db5f-d58b-4dbf-9f27-aadfa481f559"), "category_icon_poslugi_treneriv.svg", new Guid("17ad73db-4fd7-4dd1-a26a-b049a69a1606"), "Послуги тренерів" },
                    { new Guid("1ecb5ad5-a310-498a-b354-3dd515b665dd"), "category_icon_design.svg", new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"), "Дизайн" },
                    { new Guid("24456e3a-5c01-4e14-9d99-7277c9676f08"), "category_icon_dilovi_poslugi.svg", new Guid("c9a09ee1-56b8-43f0-9f2a-51b1f05b8a3e"), "Ділові послуги" },
                    { new Guid("25bafeec-da51-46e5-a160-9596e6aad7b6"), "category_icon_organizacia_sviat.svg", new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), "Організація свят" },
                    { new Guid("2d2dc17a-abfd-4e1c-ab88-b8dc7e72dfe8"), "category_icon_transportni_skladski_poslugi.svg", new Guid("443f7547-3a93-438b-b6d5-7f5cac0a3e13"), "Транспортні та складські послуги" },
                    { new Guid("2ff6ac44-616c-491e-99a4-184b12719b35"), "category_icon_ozdoblyvalni_roboti.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Оздоблювальні роботи" },
                    { new Guid("36c0821a-9317-4456-ad19-8aa73a805453"), "category_icon_photo_i_video.svg", new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), "Фото- і відео-послуги" },
                    { new Guid("39196572-1e31-4cdd-bcee-b42fd0922dd4"), "category_icon_poslugi_krasi_i_zdorovia.svg", new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), "Послуги краси і здоров'я" },
                    { new Guid("3ed80317-e242-4804-afdf-20dd8ffc1414"), "category_icon_volonterska_dopomoga.svg", new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), "Волонтерська допомога" },
                    { new Guid("413efb83-bd36-425d-a5e4-0b9d13888d7b"), "category_icon_budivelni_roboti.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Будівельні роботи" },
                    { new Guid("59e69eb2-b25d-40fa-ae1b-2e131e5ee44b"), "category_icon_remont_texniki.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Ремонт техніки" },
                    { new Guid("7f86e643-cadd-4dea-9a76-22987ec2667b"), "category_icon_pobutovi_poslugi.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Побутові послуги" },
                    { new Guid("8183db09-7cfe-4017-89b9-6f40f45119ee"), "category_icon_remont_avto.svg", new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"), "Ремонт авто" },
                    { new Guid("a518d3c3-2fe5-4746-a4e5-e59ea9607ee0"), "category_icon_meblevi_roboti.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Меблеві роботи" },
                    { new Guid("b1423856-84b3-49ad-9ff1-57fd45e2d8d4"), "category_icon_kurerski_poslugi.svg", new Guid("443f7547-3a93-438b-b6d5-7f5cac0a3e13"), "Кур'єрські послуги" },
                    { new Guid("ba194614-fdc8-4830-bde0-647532e7da46"), "category_icon_cliningovi_poslugi.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Клінінгові послуги" },
                    { new Guid("ba72f604-2c3f-42a1-9838-8a4ab3e4f9be"), "category_icon_poslugi_dlya_tvarin.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Послуги для тварин" },
                    { new Guid("e6f62be5-4676-41f6-91cc-b4f8b035503d"), "category_icon_reklama_v_interneti.svg", new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"), "Реклама в Інтернеті" },
                    { new Guid("ef5ed6a2-3fda-4307-97a5-e6600d8e1c52"), "category_icon_domashniy_master.svg", new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"), "Домашній майстер" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("00b3cc7c-7f0e-4061-a7e7-eec8e8d98972"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("09696c51-d66a-4e9c-a830-ec4518419b1f"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("0afc549d-c57c-48e5-aa35-de0000bb7179"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("104dda7e-6050-4a3b-b58c-64ba8f77cd20"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("1252db5f-d58b-4dbf-9f27-aadfa481f559"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("1ecb5ad5-a310-498a-b354-3dd515b665dd"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("24456e3a-5c01-4e14-9d99-7277c9676f08"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("25bafeec-da51-46e5-a160-9596e6aad7b6"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("2d2dc17a-abfd-4e1c-ab88-b8dc7e72dfe8"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("2ff6ac44-616c-491e-99a4-184b12719b35"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("36c0821a-9317-4456-ad19-8aa73a805453"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("39196572-1e31-4cdd-bcee-b42fd0922dd4"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("3ed80317-e242-4804-afdf-20dd8ffc1414"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("413efb83-bd36-425d-a5e4-0b9d13888d7b"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("59e69eb2-b25d-40fa-ae1b-2e131e5ee44b"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("7f86e643-cadd-4dea-9a76-22987ec2667b"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("8183db09-7cfe-4017-89b9-6f40f45119ee"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("a518d3c3-2fe5-4746-a4e5-e59ea9607ee0"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("b1423856-84b3-49ad-9ff1-57fd45e2d8d4"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba194614-fdc8-4830-bde0-647532e7da46"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba72f604-2c3f-42a1-9838-8a4ab3e4f9be"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6f62be5-4676-41f6-91cc-b4f8b035503d"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("ef5ed6a2-3fda-4307-97a5-e6600d8e1c52"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("08f60624-5d16-4fff-9d2a-004a2087d0e6"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("17ad73db-4fd7-4dd1-a26a-b049a69a1606"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("443f7547-3a93-438b-b6d5-7f5cac0a3e13"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("8d894f67-5f26-43a6-8984-5fdd6628d7fa"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("c9a09ee1-56b8-43f0-9f2a-51b1f05b8a3e"));

            migrationBuilder.DeleteData(
                table: "CategoriesOfCategories",
                keyColumn: "Id",
                keyValue: new Guid("e08a3dc0-c504-45ee-b5db-fd20c60c5dd4"));

            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "DataTemplates");
        }
    }
}
