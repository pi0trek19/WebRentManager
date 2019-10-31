using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class rents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Milage",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedUntil",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IdNumber1 = table.Column<string>(nullable: true),
                    IdNumber2 = table.Column<string>(nullable: true),
                    IdNumber3 = table.Column<string>(nullable: true),
                    RepName = table.Column<string>(nullable: true),
                    RepMail = table.Column<string>(nullable: true),
                    RepPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilageRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Milage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilageRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilageRecords_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RentFee = table.Column<decimal>(nullable: false),
                    DamageFee = table.Column<int>(nullable: false),
                    MilageLimit = table.Column<int>(nullable: false),
                    OverMilageFee = table.Column<decimal>(nullable: false),
                    TyresIncluded = table.Column<bool>(nullable: false),
                    ServiceIncluded = table.Column<bool>(nullable: false),
                    AssistanceIncluded = table.Column<bool>(nullable: false),
                    ReplacementCarIncluded = table.Column<bool>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HandoverDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    RentId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    IsTermAccepted = table.Column<bool>(nullable: false),
                    StartMilage = table.Column<int>(nullable: false),
                    StartFuel = table.Column<int>(nullable: false),
                    StartNotes = table.Column<string>(nullable: true),
                    StartManual = table.Column<bool>(nullable: false),
                    StartService = table.Column<bool>(nullable: false),
                    StartTriangle = table.Column<bool>(nullable: false),
                    StartFireEx = table.Column<bool>(nullable: false),
                    StartSpare = table.Column<bool>(nullable: false),
                    StartRepairSet = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartCientSignature = table.Column<string>(nullable: true),
                    StartCompanySignature = table.Column<string>(nullable: true),
                    EndMilage = table.Column<int>(nullable: false),
                    EndFuel = table.Column<int>(nullable: false),
                    EndNotes = table.Column<string>(nullable: true),
                    EndManual = table.Column<bool>(nullable: false),
                    EndService = table.Column<bool>(nullable: false),
                    EndTriangle = table.Column<bool>(nullable: false),
                    EndFireEx = table.Column<bool>(nullable: false),
                    EndSpare = table.Column<bool>(nullable: false),
                    EndRepairSet = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndClientSignature = table.Column<string>(nullable: true),
                    EndCompanySignature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HandoverDocument_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HandoverDocument_RentId",
                table: "HandoverDocument",
                column: "RentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilageRecords_CarId",
                table: "MilageRecords",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "HandoverDocument");

            migrationBuilder.DropTable(
                name: "MilageRecords");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Milage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ReservedUntil",
                table: "Cars");
        }
    }
}
