using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusyBee.Persistence.Design.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesOfCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesOfCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesOfCategories_CategoriesOfCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoriesOfCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesOfTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderAddressDataTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentDataTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesOfTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesOfTasks_CategoriesOfCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoriesOfCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesOfTasks_DataTemplates_OrderAddressDataTemplateId",
                        column: x => x.OrderAddressDataTemplateId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesOfTasks_DataTemplates_PaymentDataTemplateId",
                        column: x => x.PaymentDataTemplateId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataTemplateItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DataTemplateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTemplateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTemplateItems_DataTemplates_DataTemplateId",
                        column: x => x.DataTemplateId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ConfidentialInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_CategoriesOfTasks_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesOfTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataTemplateItemValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTemplateItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    AddedMoney = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTemplateItemValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTemplateItemValues_DataTemplateItems_DataTemplateItemId",
                        column: x => x.DataTemplateItemId,
                        principalTable: "DataTemplateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskDataValues",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTemplateItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDataValues", x => new { x.TaskId, x.DataTemplateItemId });
                    table.ForeignKey(
                        name: "FK_TaskDataValues_DataTemplateItems_DataTemplateItemId",
                        column: x => x.DataTemplateItemId,
                        principalTable: "DataTemplateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskDataValues_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskDataTemplateItemValues",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTemplateItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTemplateItemValueId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDataTemplateItemValues", x => new { x.TaskId, x.DataTemplateItemId, x.DataTemplateItemValueId });
                    table.ForeignKey(
                        name: "FK_TaskDataTemplateItemValues_DataTemplateItemValues_DataTempl~",
                        column: x => x.DataTemplateItemValueId,
                        principalTable: "DataTemplateItemValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskDataTemplateItemValues_DataTemplateItems_DataTemplateIt~",
                        column: x => x.DataTemplateItemId,
                        principalTable: "DataTemplateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskDataTemplateItemValues_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesOfCategories_ParentId",
                table: "CategoriesOfCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesOfTasks_OrderAddressDataTemplateId",
                table: "CategoriesOfTasks",
                column: "OrderAddressDataTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesOfTasks_ParentId",
                table: "CategoriesOfTasks",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesOfTasks_PaymentDataTemplateId",
                table: "CategoriesOfTasks",
                column: "PaymentDataTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTemplateItems_DataTemplateId",
                table: "DataTemplateItems",
                column: "DataTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTemplateItemValues_DataTemplateItemId",
                table: "DataTemplateItemValues",
                column: "DataTemplateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDataTemplateItemValues_DataTemplateItemId",
                table: "TaskDataTemplateItemValues",
                column: "DataTemplateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDataTemplateItemValues_DataTemplateItemValueId",
                table: "TaskDataTemplateItemValues",
                column: "DataTemplateItemValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDataValues_DataTemplateItemId",
                table: "TaskDataValues",
                column: "DataTemplateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDataTemplateItemValues");

            migrationBuilder.DropTable(
                name: "TaskDataValues");

            migrationBuilder.DropTable(
                name: "DataTemplateItemValues");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "DataTemplateItems");

            migrationBuilder.DropTable(
                name: "CategoriesOfTasks");

            migrationBuilder.DropTable(
                name: "CategoriesOfCategories");

            migrationBuilder.DropTable(
                name: "DataTemplates");
        }
    }
}
