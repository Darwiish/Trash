using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashVersionOne.Data.Migrations
{
    public partial class ProductAddCreatedByProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "OrderTable");

            //migrationBuilder.AddColumn<string>(
            //    name: "CreatedBy",
            //    table: "ProductDetails",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Shipped = table.Column<bool>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Line1 = table.Column<string>(nullable: false),
            //        Line2 = table.Column<string>(nullable: true),
            //        Line3 = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: false),
            //        State = table.Column<string>(nullable: false),
            //        Zip = table.Column<string>(nullable: true),
            //        Country = table.Column<string>(nullable: false),
            //        GiftWrap = table.Column<bool>(nullable: false),
            //        ProductDetailsId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Orders_ProductDetails_ProductDetailsId",
            //            column: x => x.ProductDetailsId,
            //            principalTable: "ProductDetails",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CartLine",
            //    columns: table => new
            //    {
            //        CartLineID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductId = table.Column<int>(nullable: true),
            //        Quantity = table.Column<int>(nullable: false),
            //        OrdersId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CartLine", x => x.CartLineID);
            //        table.ForeignKey(
            //            name: "FK_CartLine_Orders_OrdersId",
            //            column: x => x.OrdersId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CartLine_ProductDetails_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "ProductDetails",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartLine_OrdersId",
            //    table: "CartLine",
            //    column: "OrdersId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartLine_ProductId",
            //    table: "CartLine",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ProductDetailsId",
            //    table: "Orders",
            //    column: "ProductDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductDetails");

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    DateToSend = table.Column<DateTime>(nullable: false),
                    ProNo = table.Column<string>(nullable: true),
                    ProductDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTable_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_ProductDetailsId",
                table: "OrderTable",
                column: "ProductDetailsId");
        }
    }
}
