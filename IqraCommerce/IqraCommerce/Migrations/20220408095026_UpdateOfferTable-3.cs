using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateOfferTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offer");

            migrationBuilder.AddColumn<string>(
                name: "Headline",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingAt",
                table: "Offer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Headline",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "StartingAt",
                table: "Offer");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
