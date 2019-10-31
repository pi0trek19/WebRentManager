using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.ViewModels;

namespace WebRentManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceFacility> ServiceFacilities { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TyreInfo> TyreInfos { get; set; }
        public DbSet<TyreShop> TyreShops { get; set; }
        public DbSet<FinancialInfo> FinancialInfos { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MilageRecord> MilageRecords { get; set; }
        public DbSet<CarExpense> CarExpenses { get; set; }
        public DbSet<CarDamage> CarDamages { get; set; }
        public DbSet<HandoverDocument> HandoverDocuments { get; set; }
    }
}
