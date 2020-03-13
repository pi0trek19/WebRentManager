using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class updatedDamage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateMarked",
                table: "CarDamages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEndDamage",
                table: "CarDamages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RentId",
                table: "CarDamages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarDamages_RentId",
                table: "CarDamages",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamages_Rents_RentId",
                table: "CarDamages",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDamages_Rents_RentId",
                table: "CarDamages");

            migrationBuilder.DropIndex(
                name: "IX_CarDamages_RentId",
                table: "CarDamages");

            migrationBuilder.DropColumn(
                name: "DateMarked",
                table: "CarDamages");

            migrationBuilder.DropColumn(
                name: "IsEndDamage",
                table: "CarDamages");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "CarDamages");
        }
    }
}
