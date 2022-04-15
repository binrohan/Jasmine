using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateShippingAddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UpazilaId",
                table: "ShippingAddress",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProvinceId",
                table: "ShippingAddress",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DistrictId",
                table: "ShippingAddress",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpazilaId",
                table: "ShippingAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "ShippingAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "ShippingAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
