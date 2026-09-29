using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class changes5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_catalog.Category_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_catalog.Category",
                schema: "catalog",
                table: "catalog.Category");

            migrationBuilder.RenameTable(
                name: "catalog.Category",
                schema: "catalog",
                newName: "Category",
                newSchema: "catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "catalog",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products",
                column: "ProducerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "catalog",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "catalog",
                newName: "catalog.Category",
                newSchema: "catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalog.Category",
                schema: "catalog",
                table: "catalog.Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products",
                column: "ProducerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_catalog.Category_CategoryId",
                schema: "catalog",
                table: "Products",
                column: "CategoryId",
                principalSchema: "catalog",
                principalTable: "catalog.Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
