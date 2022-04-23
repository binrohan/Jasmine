using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IqraCommerce.Migrations
{
    public partial class UpdateNoticeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveAt",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "NoticeContent",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notice");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Notice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Notice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Notice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Notice");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveAt",
                table: "Notice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "Notice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NoticeContent",
                table: "Notice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Notice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
