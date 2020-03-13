using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class MoreCarData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EngineSize",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GearboxType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NextServiceMilage",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextTechCheckDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PowerHP",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PowerkW",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ServiceInterval",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecType",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineSize",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GearboxType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NextServiceMilage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NextTechCheckDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerHP",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerkW",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ServiceInterval",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SpecType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Cars");
        }
    }
}
