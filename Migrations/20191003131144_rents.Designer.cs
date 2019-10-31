﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRentManager.Models;

namespace WebRentManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191003131144_rents")]
    partial class rents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebRentManager.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsReserved");

                    b.Property<string>("Make");

                    b.Property<int>("Milage");

                    b.Property<string>("Model");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("RegistrationNumber");

                    b.Property<DateTime>("ReservedUntil");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebRentManager.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("ClientType");

                    b.Property<string>("IdNumber1");

                    b.Property<string>("IdNumber2");

                    b.Property<string>("IdNumber3");

                    b.Property<string>("Name");

                    b.Property<string>("RepMail");

                    b.Property<string>("RepName");

                    b.Property<string>("RepPhone");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebRentManager.Models.FinancialInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankName");

                    b.Property<Guid>("CarId");

                    b.Property<string>("Company");

                    b.Property<decimal>("EndBuyoutNetPrice");

                    b.Property<DateTime>("LeaseEndDate");

                    b.Property<DateTime>("LeaseStartDate");

                    b.Property<int>("LeaseTime");

                    b.Property<string>("LeaseType");

                    b.Property<decimal>("MonthlyLeaseFee");

                    b.Property<decimal>("StartNetPrice");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("FinancialInfos");
                });

            modelBuilder.Entity("WebRentManager.Models.HandoverDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<Guid>("ClientId");

                    b.Property<string>("EndClientSignature");

                    b.Property<string>("EndCompanySignature");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("EndFireEx");

                    b.Property<int>("EndFuel");

                    b.Property<bool>("EndManual");

                    b.Property<int>("EndMilage");

                    b.Property<string>("EndNotes");

                    b.Property<bool>("EndRepairSet");

                    b.Property<bool>("EndService");

                    b.Property<bool>("EndSpare");

                    b.Property<bool>("EndTriangle");

                    b.Property<bool>("IsTermAccepted");

                    b.Property<Guid>("RentId");

                    b.Property<string>("StartCientSignature");

                    b.Property<string>("StartCompanySignature");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("StartFireEx");

                    b.Property<int>("StartFuel");

                    b.Property<bool>("StartManual");

                    b.Property<int>("StartMilage");

                    b.Property<string>("StartNotes");

                    b.Property<bool>("StartRepairSet");

                    b.Property<bool>("StartService");

                    b.Property<bool>("StartSpare");

                    b.Property<bool>("StartTriangle");

                    b.HasKey("Id");

                    b.HasIndex("RentId")
                        .IsUnique();

                    b.ToTable("HandoverDocument");
                });

            modelBuilder.Entity("WebRentManager.Models.MilageRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Milage");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("MilageRecords");
                });

            modelBuilder.Entity("WebRentManager.Models.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AssistanceIncluded");

                    b.Property<Guid>("CarId");

                    b.Property<Guid>("ClientId");

                    b.Property<int>("DamageFee");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsFinished");

                    b.Property<int>("MilageLimit");

                    b.Property<decimal>("OverMilageFee");

                    b.Property<decimal>("RentFee");

                    b.Property<bool>("ReplacementCarIncluded");

                    b.Property<bool>("ServiceIncluded");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("TyresIncluded");

                    b.HasKey("Id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("WebRentManager.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Milage");

                    b.Property<Guid>("ServiceFacilityId");

                    b.Property<int>("ServiceType");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceFacilityId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebRentManager.Models.ServiceFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("ServiceFacilities");
                });

            modelBuilder.Entity("WebRentManager.Models.TyreInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<int>("Diameter");

                    b.Property<int>("Dot");

                    b.Property<int>("Profile");

                    b.Property<string>("SpeedIndex");

                    b.Property<string>("TyreName");

                    b.Property<Guid>("TyreShopId");

                    b.Property<int>("TyreStatus");

                    b.Property<int>("TyreType");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("TyreShopId");

                    b.ToTable("TyreInfos");
                });

            modelBuilder.Entity("WebRentManager.Models.TyreShop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("SaturdayHours");

                    b.Property<string>("Street");

                    b.Property<string>("SundayHours");

                    b.Property<string>("WeekHours");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("TyreShops");
                });

            modelBuilder.Entity("WebRentManager.Models.FinancialInfo", b =>
                {
                    b.HasOne("WebRentManager.Models.Car")
                        .WithOne("FinancialInfo")
                        .HasForeignKey("WebRentManager.Models.FinancialInfo", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.HandoverDocument", b =>
                {
                    b.HasOne("WebRentManager.Models.Rent")
                        .WithOne("Handover")
                        .HasForeignKey("WebRentManager.Models.HandoverDocument", "RentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.MilageRecord", b =>
                {
                    b.HasOne("WebRentManager.Models.Car")
                        .WithMany("MilageHistory")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.Service", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany("Services")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.ServiceFacility", "ServiceFacility")
                        .WithMany()
                        .HasForeignKey("ServiceFacilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.TyreInfo", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany("TyreInfos")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.TyreShop", "TyreShop")
                        .WithMany()
                        .HasForeignKey("TyreShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
