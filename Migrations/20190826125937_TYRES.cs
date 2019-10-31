using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class TYRES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TyreStatus",
                table: "TyreInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TyreType",
                table: "TyreInfos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TyreStatus",
                table: "TyreInfos");

            migrationBuilder.DropColumn(
                name: "TyreType",
                table: "TyreInfos");
        }
    }
}
