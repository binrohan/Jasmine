using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsVatExcluded",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "SearchQuery",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchQuery",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVatExcluded",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
