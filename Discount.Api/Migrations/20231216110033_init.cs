using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "discount");

            migrationBuilder.CreateTable(
                name: "Discounts",
                schema: "discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "discount",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalProductId = table.Column<int>(type: "int", nullable: false),
                    DiscountModelDiscountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_DiscountModelDiscountId",
                        column: x => x.DiscountModelDiscountId,
                        principalSchema: "discount",
                        principalTable: "Discounts",
                        principalColumn: "DiscountId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountModelDiscountId",
                schema: "discount",
                table: "Products",
                column: "DiscountModelDiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "discount");

            migrationBuilder.DropTable(
                name: "Discounts",
                schema: "discount");
        }
    }
}
