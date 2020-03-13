using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class carFilesTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarFile",
                columns: table => new
                {
                    CarId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFile", x => new { x.CarId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_CarFile_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarFile_FileDescriptionId",
                table: "CarFile",
                column: "FileDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarFile");
        }
    }
}
