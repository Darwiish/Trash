using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashVersionOne.Data.Migrations
{
    public partial class orderDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CartLine_Orders_OrdersId",
            //    table: "CartLine");

            //migrationBuilder.RenameColumn(
            //    name: "Id",
            //    table: "Orders",
            //    newName: "OrderID");

            //migrationBuilder.RenameColumn(
            //    name: "OrdersId",
            //    table: "CartLine",
            //    newName: "OrderID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CartLine_OrdersId",
            //    table: "CartLine",
            //    newName: "IX_CartLine_OrderID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CartLine_Orders_OrderID",
            //    table: "CartLine",
            //    column: "OrderID",
            //    principalTable: "Orders",
            //    principalColumn: "OrderID",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Orders_OrderID",
                table: "CartLine");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "CartLine",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_CartLine_OrderID",
                table: "CartLine",
                newName: "IX_CartLine_OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Orders_OrdersId",
                table: "CartLine",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
