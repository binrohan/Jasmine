using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class EditBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Brand");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Brand",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
