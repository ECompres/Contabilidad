﻿using Contabilidad.Configurations;
using Microsoft.EntityFrameworkCore;
using Contabilidad.Models;
using Accounting;
using Accounting.Configurations;

namespace Contabilidad.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountingAccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountingEntryConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuxiliarSystemConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());


            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AccountingAccount> AccountingAccount { get; set; }
        public DbSet<AccountingEntry> AccountingEntry { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<AuxiliarSystem> AuxiliarSystem { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
    }
}