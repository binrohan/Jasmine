using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateCashbackHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Cashback");

            migrationBuilder.AddColumn<Guid>(
                name: "CashbackId",
                table: "CashbackHistory",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashbackId",
                table: "CashbackHistory");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Cashback",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
