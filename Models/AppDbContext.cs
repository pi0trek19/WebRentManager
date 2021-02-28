using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.ViewModels;

namespace WebRentManager.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CarFile
            //pliki samochodu
            modelBuilder.Entity<CarFile>()
            .HasKey(t => new { t.CarId, t.FileDescriptionId });

            modelBuilder.Entity<CarFile>()
                .HasOne(pt => pt.Car)
                .WithMany(p => p.CarFiles)
                .HasForeignKey(pt => pt.CarId);

            modelBuilder.Entity<CarFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.CarFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region ClientFile
            modelBuilder.Entity<ClientFile>()
           .HasKey(t => new { t.ClientId, t.FileDescriptionId });

            modelBuilder.Entity<ClientFile>()
                .HasOne(pt => pt.Client)
                .WithMany(p => p.ClientFiles)
                .HasForeignKey(pt => pt.ClientId);

            modelBuilder.Entity<ClientFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.ClientFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region RentFile
            modelBuilder.Entity<RentFile>()
           .HasKey(t => new { t.RentId, t.FileDescriptionId });

            modelBuilder.Entity<RentFile>()
                .HasOne(pt => pt.Rent)
                .WithMany(p => p.RentFiles)
                .HasForeignKey(pt => pt.RentId);

            modelBuilder.Entity<RentFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.RentFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region CarDamageFile
            modelBuilder.Entity<CarDamageFile>()
            .HasKey(t => new { t.CarDamageId, t.FileDescriptionId });

            modelBuilder.Entity<CarDamageFile>()
                .HasOne(pt => pt.CarDamage)
                .WithMany(p => p.CarDamageFiles)
                .HasForeignKey(pt => pt.CarDamageId);

            modelBuilder.Entity<CarDamageFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.CarDamageFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region ServiceFile
            modelBuilder.Entity<ServiceFile>()
            .HasKey(t => new { t.ServiceId, t.FileDescriptionId });

            modelBuilder.Entity<ServiceFile>()
                .HasOne(pt => pt.Service)
                .WithMany(p => p.ServiceFiles)
                .HasForeignKey(pt => pt.ServiceId);

            modelBuilder.Entity<ServiceFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.ServiceFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region HandoverDocumentFile
            modelBuilder.Entity<HandoverDocumentFile>()
            .HasKey(t => new { t.HandoverDocumentId, t.FileDescriptionId });

            modelBuilder.Entity<HandoverDocumentFile>()
                .HasOne(pt => pt.HandoverDocument)
                .WithMany(p => p.HandoverDocumentFiles)
                .HasForeignKey(pt => pt.HandoverDocumentId);

            modelBuilder.Entity<HandoverDocumentFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.HandoverDocumentFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region CarExpenseFile
            modelBuilder.Entity<CarExpenseFile>()
            .HasKey(t => new { t.CarExpenseId, t.FileDescriptionId });

            modelBuilder.Entity<CarExpenseFile>()
                .HasOne(pt => pt.CarExpense)
                .WithMany(p => p.CarExpenseFiles)
                .HasForeignKey(pt => pt.CarExpenseId);

            modelBuilder.Entity<CarExpenseFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.CarExpenseFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region InsuranceClaimFile
            modelBuilder.Entity<InsuranceClaimFile>()
            .HasKey(t => new { t.InsuranceClaimId, t.FileDescriptionId });

            modelBuilder.Entity<InsuranceClaimFile>()
                .HasOne(pt => pt.InsuranceClaim)
                .WithMany(p => p.InsuranceClaimFiles)
                .HasForeignKey(pt => pt.InsuranceClaimId);

            modelBuilder.Entity<InsuranceClaimFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.InsuranceClaimFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion
            #region InsurancePolicyFile
            modelBuilder.Entity<InsurancePolicyFile>()
            .HasKey(t => new { t.InsurancePolicyId, t.FileDescriptionId });

            modelBuilder.Entity<InsurancePolicyFile>()
                .HasOne(pt => pt.InsurancePolicy)
                .WithMany(p => p.InsurancePolicyFiles)
                .HasForeignKey(pt => pt.InsurancePolicyId);

            modelBuilder.Entity<InsurancePolicyFile>()
                .HasOne(pt => pt.FileDescription)
                .WithMany(t => t.InsurancePolicyFiles)
                .HasForeignKey(pt => pt.FileDescriptionId);
            #endregion

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TyreInfo> TyreInfos { get; set; }
        public DbSet<TyreShop> TyreShops { get; set; }
        public DbSet<FinancialInfo> FinancialInfos { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MilageRecord> MilageRecords { get; set; }
        public DbSet<CarExpense> CarExpenses { get; set; }
        public DbSet<HandoverDocument> HandoverDocuments { get; set; }
        public DbSet<CarDamage> CarDamages { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; }
        public DbSet<FileDescription> FileDescriptions { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<CarFile> CarFile { get; set; }
        public DbSet<ClientFile> ClientFile { get; set; }  
        public DbSet<RentFile> RentFile { get; set; } 
        public DbSet<HandoverDocumentFile> HandoverDocumentFile { get; set; } 
        public DbSet<InsuranceClaimFile> InsuranceClaimFile { get; set; } 
        public DbSet<ServiceFile> ServiceFile { get; set; } 
        public DbSet<CarExpenseFile> CarExpenseFile { get; set; } 
        public DbSet<CarDamageFile> CarDamageFile { get; set; }
        public DbSet<InsurancePolicyFile> InsurancePolicyFile { get; set; }
        public DbSet<CashDepositAction> CashDepositActions { get; set; }
        public DbSet<CashDeposit> CashDeposits { get; set; }
    }
}
