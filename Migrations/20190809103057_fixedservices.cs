using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class fixedservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceFacilityId",
                table: "Services",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services",
                column: "ServiceFacilityId",
                principalTable: "ServiceFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceFacilityId",
                table: "Services",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services",
                column: "ServiceFacilityId",
                principalTable: "ServiceFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
