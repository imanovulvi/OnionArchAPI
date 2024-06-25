using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionArchAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "IsDelete", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(92), false, "Defakto" },
                    { 2, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(97), false, "Kigili" },
                    { 3, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(99), false, "Rodrigos" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "IsDelete", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3341), false, "Electronika", 0, 1 },
                    { 2, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3346), false, "Notebook", 1, 1 },
                    { 3, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3347), false, "Phone", 1, 2 },
                    { 4, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3349), false, "Geyim", 0, 3 },
                    { 5, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3351), false, "Tshort", 4, 1 },
                    { 6, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3352), false, "Cins", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreateDate", "Description", "IsDelete", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6000), "Cotton", false, "Material" },
                    { 2, 2, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6007), "8gb", false, "Ram" },
                    { 3, 6, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6009), "125sm", false, "Uzunluq" },
                    { 4, 3, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6011), "50px", false, "Cekilis" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "IsDelete", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8510), "test", false, 34m, "Kofta" },
                    { 2, 3, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8518), "test", false, 158m, "Iphone" },
                    { 3, 2, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8520), "test", false, 346m, "Notebook" },
                    { 4, 1, new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8522), "test", false, 12m, "salvar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
