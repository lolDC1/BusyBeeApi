using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class EditCategoryOfTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_OrderAddressDataTemplateId",
                table: "CategoriesOfTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_PaymentDataTemplateId",
                table: "CategoriesOfTasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentDataTemplateId",
                table: "CategoriesOfTasks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderAddressDataTemplateId",
                table: "CategoriesOfTasks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_OrderAddressDataTemplateId",
                table: "CategoriesOfTasks",
                column: "OrderAddressDataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_PaymentDataTemplateId",
                table: "CategoriesOfTasks",
                column: "PaymentDataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_OrderAddressDataTemplateId",
                table: "CategoriesOfTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_PaymentDataTemplateId",
                table: "CategoriesOfTasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentDataTemplateId",
                table: "CategoriesOfTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderAddressDataTemplateId",
                table: "CategoriesOfTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_OrderAddressDataTemplateId",
                table: "CategoriesOfTasks",
                column: "OrderAddressDataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesOfTasks_DataTemplates_PaymentDataTemplateId",
                table: "CategoriesOfTasks",
                column: "PaymentDataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
