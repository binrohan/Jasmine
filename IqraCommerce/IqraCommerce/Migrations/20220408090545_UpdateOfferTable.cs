using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temp",
                table: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Offer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "Temp",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
