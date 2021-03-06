// <auto-generated />
using System;
using Contabilidad.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210307155457_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contabilidad.Models.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("Contabilidad.Models.AccountingAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAccountType")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("MajorAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TransactionsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("IdAccountType");

                    b.ToTable("AccountingAccount");
                });

            modelBuilder.Entity("Contabilidad.Models.AccountingEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAuxiliarSystem")
                        .HasColumnType("int");

                    b.Property<string>("MovementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SeatAmount")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("IdAuxiliarSystem");

                    b.ToTable("AccountingEntry");
                });

            modelBuilder.Entity("Contabilidad.Models.AuxiliarSystem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("AuxiliarSystem");
                });

            modelBuilder.Entity("Contabilidad.Models.CurrencyType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastExchangeRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("CurrencyType");
                });

            modelBuilder.Entity("Contabilidad.Models.AccountingAccount", b =>
                {
                    b.HasOne("Contabilidad.Models.AccountType", "AccountType")
                        .WithMany("AccountingAccounts")
                        .HasForeignKey("IdAccountType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("Contabilidad.Models.AccountingEntry", b =>
                {
                    b.HasOne("Contabilidad.Models.AuxiliarSystem", "AuxiliarSystem")
                        .WithMany("AccountingEntry")
                        .HasForeignKey("IdAuxiliarSystem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuxiliarSystem");
                });

            modelBuilder.Entity("Contabilidad.Models.AccountType", b =>
                {
                    b.Navigation("AccountingAccounts");
                });

            modelBuilder.Entity("Contabilidad.Models.AuxiliarSystem", b =>
                {
                    b.Navigation("AccountingEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
