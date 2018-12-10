using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashVersionOne.Data.Migrations
{
    public partial class AddProducDetailsCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductDetails");
        }
    }
}
