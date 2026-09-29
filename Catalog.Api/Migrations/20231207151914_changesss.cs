using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class changesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ProductId",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StrongName",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "ExternalDiscountId",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ExternalCommentId",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "StrongName",
                schema: "catalog",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "catalog",
                table: "Discounts",
                newName: "ExternalId");

            migrationBuilder.AlterTable(
                name: "Products",
                schema: "catalog",
                oldComment: "Table of products in catalog");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "catalog",
                table: "Producers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "catalog",
                table: "Producers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "catalog",
                table: "Discounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "catalog",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "catalog",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "catalog",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "catalog",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "catalog",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "catalog",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "catalog",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "catalog",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CategoryModelProductModel",
                schema: "catalog",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelProductModel", x => new { x.CategoriesCategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryModelProductModel_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalSchema: "catalog",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelProductModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountModelProductModel",
                schema: "catalog",
                columns: table => new
                {
                    DiscountsDiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountModelProductModel", x => new { x.DiscountsDiscountId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_DiscountModelProductModel_Discounts_DiscountsDiscountId",
                        column: x => x.DiscountsDiscountId,
                        principalSchema: "catalog",
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountModelProductModel_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalSchema: "catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                schema: "catalog",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producers_Name",
                schema: "catalog",
                table: "Producers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Code",
                schema: "catalog",
                table: "Discounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "catalog",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelProductModel_ProductId",
                schema: "catalog",
                table: "CategoryModelProductModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountModelProductModel_ProductsProductId",
                schema: "catalog",
                table: "DiscountModelProductModel",
                column: "ProductsProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModelProductModel",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "DiscountModelProductModel",
                schema: "catalog");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Producers_Name",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_Code",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Category_Name",
                schema: "catalog",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "catalog",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "catalog",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                schema: "catalog",
                table: "Discounts",
                newName: "ProductId");

            migrationBuilder.AlterTable(
                name: "Products",
                schema: "catalog",
                comment: "Table of products in catalog");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "catalog",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrongName",
                schema: "catalog",
                table: "Producers",
                type: "nvarchar(max)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExternalDiscountId",
                schema: "catalog",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExternalCommentId",
                schema: "catalog",
                table: "Comments",
                type: "nvarchar(250)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrongName",
                schema: "catalog",
                table: "Category",
                type: "nvarchar(250)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "catalog",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                schema: "catalog",
                table: "Discounts",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductId",
                schema: "catalog",
                table: "Discounts",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "catalog",
                table: "Products",
                column: "CategoryId",
                principalSchema: "catalog",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
