using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class AddCashbackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashback",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ActivityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    StartingAt = table.Column<DateTime>(nullable: false),
                    EndingAt = table.Column<DateTime>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    MinOrderValue = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashbackHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ActivityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsRedeemed = table.Column<bool>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cashback");

            migrationBuilder.DropTable(
                name: "CashbackHistory");
        }
    }
}
