using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.Api.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BasketItems_BasketItemId",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "basket");

            migrationBuilder.DropTable(
                name: "Producer",
                schema: "basket");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ProductId",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "basket",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BasketItemId",
                schema: "basket",
                table: "Products",
                newName: "ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BasketItemId",
                schema: "basket",
                table: "Products",
                newName: "IX_Products_ProducerId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "basket",
                table: "Discounts",
                newName: "ExternalId");

            migrationBuilder.RenameColumn(
                name: "ExternalDiscountId",
                schema: "basket",
                table: "Discounts",
                newName: "BasketUserId");

            migrationBuilder.RenameColumn(
                name: "ExternalCategoryId",
                schema: "basket",
                table: "Categories",
                newName: "ExternalId");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                schema: "basket",
                table: "Baskets",
                newName: "BasketUserId");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                schema: "basket",
                table: "BasketItems",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "basket",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DiscountModelDiscountId",
                schema: "basket",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InStock",
                schema: "basket",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                schema: "basket",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "basket",
                table: "Discounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Used",
                schema: "basket",
                table: "Discounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "basket",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BasketId1",
                schema: "basket",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasketUser",
                schema: "basket",
                columns: table => new
                {
                    BasketUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Files_Photo = table.Column<int>(type: "int", nullable: true),
                    Files_Documents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketUser", x => x.BasketUserId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryModelProductModel",
                schema: "basket",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelProductModel", x => new { x.CategoriesCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryModelProductModel_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalSchema: "basket",
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelProductModel_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalSchema: "basket",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducerModel",
                schema: "basket",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerModel", x => x.ProducerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountModelDiscountId",
                schema: "basket",
                table: "Products",
                column: "DiscountModelDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                schema: "basket",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BasketUserId",
                schema: "basket",
                table: "Discounts",
                column: "BasketUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Code",
                schema: "basket",
                table: "Discounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "basket",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BasketUserId",
                schema: "basket",
                table: "Baskets",
                column: "BasketUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId1",
                schema: "basket",
                table: "BasketItems",
                column: "BasketId1");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                schema: "basket",
                table: "BasketItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelProductModel_ProductsProductId",
                schema: "basket",
                table: "CategoryModelProductModel",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerModel_Name",
                schema: "basket",
                table: "ProducerModel",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketId1",
                schema: "basket",
                table: "BasketItems",
                column: "BasketId1",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                schema: "basket",
                table: "BasketItems",
                column: "ProductId",
                principalSchema: "basket",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_BasketUser_BasketUserId",
                schema: "basket",
                table: "Baskets",
                column: "BasketUserId",
                principalSchema: "basket",
                principalTable: "BasketUser",
                principalColumn: "BasketUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_BasketUser_BasketUserId",
                schema: "basket",
                table: "Discounts",
                column: "BasketUserId",
                principalSchema: "basket",
                principalTable: "BasketUser",
                principalColumn: "BasketUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountModelDiscountId",
                schema: "basket",
                table: "Products",
                column: "DiscountModelDiscountId",
                principalSchema: "basket",
                principalTable: "Discounts",
                principalColumn: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducerModel_ProducerId",
                schema: "basket",
                table: "Products",
                column: "ProducerId",
                principalSchema: "basket",
                principalTable: "ProducerModel",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketId1",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_BasketUser_BasketUserId",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_BasketUser_BasketUserId",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountModelDiscountId",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducerModel_ProducerId",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BasketUser",
                schema: "basket");

            migrationBuilder.DropTable(
                name: "CategoryModelProductModel",
                schema: "basket");

            migrationBuilder.DropTable(
                name: "ProducerModel",
                schema: "basket");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountModelDiscountId",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_BasketUserId",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_Code",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                schema: "basket",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_BasketUserId",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketId1",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "DiscountModelDiscountId",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InStock",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Photos",
                schema: "basket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Used",
                schema: "basket",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "BasketId1",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                schema: "basket",
                table: "Products",
                newName: "BasketItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProducerId",
                schema: "basket",
                table: "Products",
                newName: "IX_Products_BasketItemId");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                schema: "basket",
                table: "Discounts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "BasketUserId",
                schema: "basket",
                table: "Discounts",
                newName: "ExternalDiscountId");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                schema: "basket",
                table: "Categories",
                newName: "ExternalCategoryId");

            migrationBuilder.RenameColumn(
                name: "BasketUserId",
                schema: "basket",
                table: "Baskets",
                newName: "TotalQuantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "basket",
                table: "BasketItems",
                newName: "BasketId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "basket",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                schema: "basket",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "basket",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                schema: "basket",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalSchema: "basket",
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalSchema: "basket",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                schema: "basket",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrongName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerId);
                    table.ForeignKey(
                        name: "FK_Producer_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "basket",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                schema: "basket",
                table: "Discounts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                schema: "basket",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                schema: "basket",
                table: "CategoryProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Producer_ProductId",
                schema: "basket",
                table: "Producer",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketId",
                schema: "basket",
                table: "BasketItems",
                column: "BasketId",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductId",
                schema: "basket",
                table: "Discounts",
                column: "ProductId",
                principalSchema: "basket",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BasketItems_BasketItemId",
                schema: "basket",
                table: "Products",
                column: "BasketItemId",
                principalSchema: "basket",
                principalTable: "BasketItems",
                principalColumn: "BasketItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
