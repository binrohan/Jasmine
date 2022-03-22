using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Banner");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Banner",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Banner",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Banner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Banner",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Banner");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Banner");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
