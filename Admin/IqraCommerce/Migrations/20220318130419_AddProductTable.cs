using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "Product",
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
                    ProductName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Excerpt = table.Column<string>(nullable: true),
                    PackSize = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<double>(nullable: false),
                    OriginalPrice = table.Column<double>(nullable: false),
                    DiscountedPrice = table.Column<double>(nullable: false),
                    DiscountedPercentage = table.Column<double>(nullable: false),
                    TradePrice = table.Column<double>(nullable: false),
                    SoldTradePrice = table.Column<double>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    IsVatFixedType = table.Column<bool>(nullable: false),
                    IsVatExcluded = table.Column<bool>(nullable: false),
                    SoldPrice = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false),
                    StockUnit = table.Column<int>(nullable: false),
                    SoldUnit = table.Column<int>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    IsInHomePage = table.Column<bool>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    BrandName = table.Column<string>(nullable: true),
                    IsUpComming = table.Column<bool>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false),
                    UnitName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<double>(type: "float", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });
        }
    }
}
