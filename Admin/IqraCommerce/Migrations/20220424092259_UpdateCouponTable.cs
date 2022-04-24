using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateCouponTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaibilities",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "MaxOrderValue",
                table: "Coupon");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Coupon",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxDiscount",
                table: "Coupon",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinDiscount",
                table: "Coupon",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Redeemed",
                table: "Coupon",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "MaxDiscount",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "MinDiscount",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "Redeemed",
                table: "Coupon");

            migrationBuilder.AddColumn<int>(
                name: "Avaibilities",
                table: "Coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MaxOrderValue",
                table: "Coupon",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
