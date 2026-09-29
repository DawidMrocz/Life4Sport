using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalog.Category_Product_ProductId",
                table: "catalog.Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Product_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Product_ProductId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Product_ProductId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Product_ProductId",
                table: "Producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "Products",
                table: "Product");

            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.RenameTable(
                name: "Producers",
                newName: "Producers",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photo",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discounts",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "catalog.Category",
                newName: "catalog.Category",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Products",
                newName: "Products",
                newSchema: "catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "catalog",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_catalog.Category_Products_ProductId",
                schema: "catalog",
                table: "catalog.Category",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                schema: "catalog",
                table: "Comments",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Photo_Products_ProductId",
                schema: "catalog",
                table: "Photo",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Products_ProductId",
                schema: "catalog",
                table: "Producers",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalog.Category_Products_ProductId",
                schema: "catalog",
                table: "catalog.Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                schema: "catalog",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                schema: "catalog",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Products_ProductId",
                schema: "catalog",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Products_ProductId",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "catalog",
                table: "Products");

            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.RenameTable(
                name: "Producers",
                schema: "catalog",
                newName: "Producers");

            migrationBuilder.RenameTable(
                name: "Photo",
                schema: "catalog",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "Discounts",
                schema: "catalog",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "catalog",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "catalog.Category",
                schema: "catalog",
                newName: "catalog.Category");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "catalog",
                newName: "Product",
                newSchema: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "Products",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_catalog.Category_Product_ProductId",
                table: "catalog.Category",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Product_ProductId",
                table: "Comments",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Product_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Product_ProductId",
                table: "Photo",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Product_ProductId",
                table: "Producers",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
