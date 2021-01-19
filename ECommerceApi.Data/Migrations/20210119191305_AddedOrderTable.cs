using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApi.Infastructure.Migrations
{
    public partial class AddedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sku_Products_ProductId",
                table: "Sku");

            migrationBuilder.DropForeignKey(
                name: "FK_Sku_Sku_SkuId",
                table: "Sku");

            migrationBuilder.DropForeignKey(
                name: "FK_Sku_Variant_VariantId",
                table: "Sku");

            migrationBuilder.DropForeignKey(
                name: "FK_Variant_Products_ProductId",
                table: "Variant");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantOption_Products_ProductId",
                table: "VariantOption");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantOption_Variant_VariantId",
                table: "VariantOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantOption",
                table: "VariantOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sku",
                table: "Sku");

            migrationBuilder.RenameTable(
                name: "VariantOption",
                newName: "VariantOptions");

            migrationBuilder.RenameTable(
                name: "Variant",
                newName: "Variants");

            migrationBuilder.RenameTable(
                name: "Sku",
                newName: "Skus");

            migrationBuilder.RenameIndex(
                name: "IX_VariantOption_VariantId",
                table: "VariantOptions",
                newName: "IX_VariantOptions_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantOption_ProductId",
                table: "VariantOptions",
                newName: "IX_VariantOptions_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Variant_ProductId",
                table: "Variants",
                newName: "IX_Variants_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sku_VariantId",
                table: "Skus",
                newName: "IX_Skus_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_Sku_SkuId",
                table: "Skus",
                newName: "IX_Skus_SkuId");

            migrationBuilder.RenameIndex(
                name: "IX_Sku_ProductId",
                table: "Skus",
                newName: "IX_Skus_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CartLineId",
                table: "Skus",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantOptions",
                table: "VariantOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variants",
                table: "Variants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skus",
                table: "Skus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartLines_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SkuId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Skus_SkuId",
                        column: x => x.SkuId,
                        principalTable: "Skus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skus_CartLineId",
                table: "Skus",
                column: "CartLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_CartId",
                table: "CartLines",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_SkuId",
                table: "OrderLines",
                column: "SkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skus_CartLines_CartLineId",
                table: "Skus",
                column: "CartLineId",
                principalTable: "CartLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skus_Products_ProductId",
                table: "Skus",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skus_Skus_SkuId",
                table: "Skus",
                column: "SkuId",
                principalTable: "Skus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skus_Variants_VariantId",
                table: "Skus",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantOptions_Products_ProductId",
                table: "VariantOptions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantOptions_Variants_VariantId",
                table: "VariantOptions",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skus_CartLines_CartLineId",
                table: "Skus");

            migrationBuilder.DropForeignKey(
                name: "FK_Skus_Products_ProductId",
                table: "Skus");

            migrationBuilder.DropForeignKey(
                name: "FK_Skus_Skus_SkuId",
                table: "Skus");

            migrationBuilder.DropForeignKey(
                name: "FK_Skus_Variants_VariantId",
                table: "Skus");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantOptions_Products_ProductId",
                table: "VariantOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantOptions_Variants_VariantId",
                table: "VariantOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants");

            migrationBuilder.DropTable(
                name: "CartLines");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variants",
                table: "Variants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantOptions",
                table: "VariantOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skus",
                table: "Skus");

            migrationBuilder.DropIndex(
                name: "IX_Skus_CartLineId",
                table: "Skus");

            migrationBuilder.DropColumn(
                name: "CartLineId",
                table: "Skus");

            migrationBuilder.RenameTable(
                name: "Variants",
                newName: "Variant");

            migrationBuilder.RenameTable(
                name: "VariantOptions",
                newName: "VariantOption");

            migrationBuilder.RenameTable(
                name: "Skus",
                newName: "Sku");

            migrationBuilder.RenameIndex(
                name: "IX_Variants_ProductId",
                table: "Variant",
                newName: "IX_Variant_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantOptions_VariantId",
                table: "VariantOption",
                newName: "IX_VariantOption_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_VariantOptions_ProductId",
                table: "VariantOption",
                newName: "IX_VariantOption_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Skus_VariantId",
                table: "Sku",
                newName: "IX_Sku_VariantId");

            migrationBuilder.RenameIndex(
                name: "IX_Skus_SkuId",
                table: "Sku",
                newName: "IX_Sku_SkuId");

            migrationBuilder.RenameIndex(
                name: "IX_Skus_ProductId",
                table: "Sku",
                newName: "IX_Sku_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantOption",
                table: "VariantOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sku",
                table: "Sku",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sku_Products_ProductId",
                table: "Sku",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sku_Sku_SkuId",
                table: "Sku",
                column: "SkuId",
                principalTable: "Sku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sku_Variant_VariantId",
                table: "Sku",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variant_Products_ProductId",
                table: "Variant",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantOption_Products_ProductId",
                table: "VariantOption",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantOption_Variant_VariantId",
                table: "VariantOption",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
