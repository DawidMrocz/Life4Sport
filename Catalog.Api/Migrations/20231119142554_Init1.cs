using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Product_ProductId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "catalog.Category");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ProductId",
                table: "catalog.Category",
                newName: "IX_catalog.Category_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalog.Category",
                table: "catalog.Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_catalog.Category_Product_ProductId",
                table: "catalog.Category",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalog.Category_Product_ProductId",
                table: "catalog.Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_catalog.Category",
                table: "catalog.Category");

            migrationBuilder.RenameTable(
                name: "catalog.Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_catalog.Category_ProductId",
                table: "Categories",
                newName: "IX_Categories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Product_ProductId",
                table: "Categories",
                column: "ProductId",
                principalSchema: "Products",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
