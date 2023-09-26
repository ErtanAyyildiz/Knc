using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knc.DataAccess.Migrations
{
    public partial class ProductModalRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountClick",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountClick",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
