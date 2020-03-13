using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class _02012020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDamages_Rents_RentId",
                table: "CarDamages");

            migrationBuilder.DropIndex(
                name: "IX_CarDamages_RentId",
                table: "CarDamages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
