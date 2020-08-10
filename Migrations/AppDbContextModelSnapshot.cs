﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRentManager.Models;

namespace WebRentManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebRentManager.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodyType");

                    b.Property<string>("Color");

                    b.Property<int>("EngineSize");

                    b.Property<int>("FuelType");

                    b.Property<int>("GearboxType");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsReserved");

                    b.Property<string>("Make");

                    b.Property<int>("Milage");

                    b.Property<string>("Model");

                    b.Property<int>("NextServiceMilage");

                    b.Property<DateTime>("NextTechCheckDate");

                    b.Property<int>("PowerHP");

                    b.Property<int>("PowerkW");

                    b.Property<int>("ProductionYear");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("RegistrationNumber");

                    b.Property<DateTime>("ReservedUntil");

                    b.Property<int>("ServiceInterval");

                    b.Property<string>("SpecType");

                    b.Property<string>("VIN");

                    b.Property<int>("YearsServiceInterval");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebRentManager.Models.CarDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<int>("DamageType");

                    b.Property<DateTime>("DateMarked");

                    b.Property<string>("Description");

                    b.Property<bool>("IsEndDamage");

                    b.Property<double>("OffsetX");

                    b.Property<double>("OffsetY");

                    b.Property<Guid>("RentId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarDamages");
                });

            modelBuilder.Entity("WebRentManager.Models.CarDamageFile", b =>
                {
                    b.Property<Guid>("CarDamageId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("CarDamageId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("CarDamageFile");
                });

            modelBuilder.Entity("WebRentManager.Models.CarExpense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("CarId");

                    b.Property<int>("CostCategory");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Decription");

                    b.Property<Guid>("FacilityId");

                    b.HasKey("Id");

                    b.ToTable("CarExpenses");
                });

            modelBuilder.Entity("WebRentManager.Models.CarExpenseFile", b =>
                {
                    b.Property<Guid>("CarExpenseId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("CarExpenseId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("CarExpenseFile");
                });

            modelBuilder.Entity("WebRentManager.Models.CarFile", b =>
                {
                    b.Property<Guid>("CarId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("CarId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("CarFile");
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

            modelBuilder.Entity("WebRentManager.Models.ClientFile", b =>
                {
                    b.Property<Guid>("ClientId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("ClientId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("ClientFile");
                });

            modelBuilder.Entity("WebRentManager.Models.FileDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackblazeFileId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Ext");

                    b.Property<string>("FileName");

                    b.Property<int>("FileType");

                    b.HasKey("Id");

                    b.ToTable("FileDescriptions");
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

                    b.ToTable("HandoverDocuments");
                });

            modelBuilder.Entity("WebRentManager.Models.HandoverDocumentFile", b =>
                {
                    b.Property<Guid>("HandoverDocumentId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("HandoverDocumentId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("HandoverDocumentFile");
                });

            modelBuilder.Entity("WebRentManager.Models.Income", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid?>("CarId");

                    b.Property<Guid>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("IncomeType");

                    b.Property<Guid>("InvoiceId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("WebRentManager.Models.InsuranceClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<DateTime>("ClaimDate");

                    b.Property<string>("ClaimNo");

                    b.Property<int>("ClaimStatus");

                    b.Property<int>("ClaimType");

                    b.Property<string>("InsuranceCompany");

                    b.Property<DateTime>("ReportDate");

                    b.Property<string>("RepresentativeMail");

                    b.Property<string>("RepresentativeName");

                    b.Property<string>("RepresentativePhone");

                    b.HasKey("Id");

                    b.ToTable("InsuranceClaims");
                });

            modelBuilder.Entity("WebRentManager.Models.InsuranceClaimFile", b =>
                {
                    b.Property<Guid>("InsuranceClaimId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("InsuranceClaimId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("InsuranceClaimFile");
                });

            modelBuilder.Entity("WebRentManager.Models.InsurancePolicy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<decimal>("Cost");

                    b.Property<string>("InsuranceCompany");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Number");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("InsurancePolicies");
                });

            modelBuilder.Entity("WebRentManager.Models.InsurancePolicyFile", b =>
                {
                    b.Property<Guid>("InsurancePolicyId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("InsurancePolicyId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("InsurancePolicyFile");
                });

            modelBuilder.Entity("WebRentManager.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("FileDescriptionId");

                    b.Property<int>("InvoiceType");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("WebRentManager.Models.MailMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Desc");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("MailMessages");
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

                    b.Property<Guid>("HandoverDocumentId");

                    b.Property<Guid?>("HandoverDocumentId1");

                    b.Property<decimal>("InitialPayment");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsEndDateSet");

                    b.Property<bool>("IsFinished");

                    b.Property<int>("MilageLimit");

                    b.Property<decimal>("OverMilageFee");

                    b.Property<decimal>("RentFee");

                    b.Property<int>("RentType");

                    b.Property<int>("RentingCompany");

                    b.Property<bool>("ReplacementCarIncluded");

                    b.Property<bool>("ServiceIncluded");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("TyresIncluded");

                    b.Property<string>("UserMail");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPhone");

                    b.HasKey("Id");

                    b.HasIndex("HandoverDocumentId1");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("WebRentManager.Models.RentFile", b =>
                {
                    b.Property<Guid>("RentId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("RentId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("RentFile");
                });

            modelBuilder.Entity("WebRentManager.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<Guid>("ClientId");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("InvoiceId");

                    b.Property<int>("Milage");

                    b.Property<int>("ServiceType");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebRentManager.Models.ServiceFile", b =>
                {
                    b.Property<Guid>("ServiceId");

                    b.Property<Guid>("FileDescriptionId");

                    b.HasKey("ServiceId", "FileDescriptionId");

                    b.HasIndex("FileDescriptionId");

                    b.ToTable("ServiceFile");
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

            modelBuilder.Entity("WebRentManager.Models.CarDamage", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.CarDamageFile", b =>
                {
                    b.HasOne("WebRentManager.Models.CarDamage", "CarDamage")
                        .WithMany("CarDamageFiles")
                        .HasForeignKey("CarDamageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("CarDamageFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.CarExpenseFile", b =>
                {
                    b.HasOne("WebRentManager.Models.CarExpense", "CarExpense")
                        .WithMany("CarExpenseFiles")
                        .HasForeignKey("CarExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("CarExpenseFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.CarFile", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany("CarFiles")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("CarFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.ClientFile", b =>
                {
                    b.HasOne("WebRentManager.Models.Client", "Client")
                        .WithMany("ClientFiles")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("ClientFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.FinancialInfo", b =>
                {
                    b.HasOne("WebRentManager.Models.Car")
                        .WithOne("FinancialInfo")
                        .HasForeignKey("WebRentManager.Models.FinancialInfo", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.HandoverDocumentFile", b =>
                {
                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("HandoverDocumentFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.HandoverDocument", "HandoverDocument")
                        .WithMany("HandoverDocumentFiles")
                        .HasForeignKey("HandoverDocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.Income", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("WebRentManager.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.InsuranceClaimFile", b =>
                {
                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("InsuranceClaimFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.InsuranceClaim", "InsuranceClaim")
                        .WithMany("InsuranceClaimFiles")
                        .HasForeignKey("InsuranceClaimId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.InsurancePolicy", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.InsurancePolicyFile", b =>
                {
                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("InsurancePolicyFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.InsurancePolicy", "InsurancePolicy")
                        .WithMany("InsurancePolicyFiles")
                        .HasForeignKey("InsurancePolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.Invoice", b =>
                {
                    b.HasOne("WebRentManager.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany()
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.MilageRecord", b =>
                {
                    b.HasOne("WebRentManager.Models.Car")
                        .WithMany("MilageHistory")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.Rent", b =>
                {
                    b.HasOne("WebRentManager.Models.HandoverDocument", "HandoverDocument")
                        .WithMany()
                        .HasForeignKey("HandoverDocumentId1");
                });

            modelBuilder.Entity("WebRentManager.Models.RentFile", b =>
                {
                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("RentFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.Rent", "Rent")
                        .WithMany("RentFiles")
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.Service", b =>
                {
                    b.HasOne("WebRentManager.Models.Car", "Car")
                        .WithMany("Services")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRentManager.Models.ServiceFile", b =>
                {
                    b.HasOne("WebRentManager.Models.FileDescription", "FileDescription")
                        .WithMany("ServiceFiles")
                        .HasForeignKey("FileDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRentManager.Models.Service", "Service")
                        .WithMany("ServiceFiles")
                        .HasForeignKey("ServiceId")
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
