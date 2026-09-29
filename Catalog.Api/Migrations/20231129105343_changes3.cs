using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class changes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalog.Category_Products_ProductId",
                schema: "catalog",
                table: "catalog.Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Products_ProductId",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Producers_ProductId",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_catalog.Category_ProductId",
                schema: "catalog",
                table: "catalog.Category");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "catalog",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "catalog",
                table: "catalog.Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                schema: "catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "catalog",
                table: "Products",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products",
                column: "ProducerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProducerId",
                schema: "catalog",
                table: "Products",
                column: "ProducerId",
                principalSchema: "catalog",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProducerId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_catalog.Category_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProducerId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "catalog",
                table: "Producers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "catalog",
                table: "catalog.Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producers_ProductId",
                schema: "catalog",
                table: "Producers",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_catalog.Category_ProductId",
                schema: "catalog",
                table: "catalog.Category",
                column: "ProductId",
                unique: true);

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
                name: "FK_Producers_Products_ProductId",
                schema: "catalog",
                table: "Producers",
                column: "ProductId",
                principalSchema: "catalog",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
