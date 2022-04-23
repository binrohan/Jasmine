using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlisht",
                table: "Wishlisht");

            migrationBuilder.RenameTable(
                name: "Wishlisht",
                newName: "Wishlist");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationBy",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "RegistrationBy",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Wishlist",
                newName: "Wishlisht");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlisht",
                table: "Wishlisht",
                column: "Id");
        }
    }
}
