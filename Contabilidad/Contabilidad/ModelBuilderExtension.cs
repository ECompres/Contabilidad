using Contabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    ID = 1,
                    Description = "Activos",
                    Origin = "DB",
                    Status = true
                },
                new AccountType
                {
                    ID = 2,
                    Description = "Pasivos",
                    Origin = "CR",
                    Status = true
                },
                new AccountType
                {
                    ID = 3,
                    Description = "Capital",
                    Origin = "CR",
                    Status = true
                },
                 new AccountType
                 {
                     ID = 4,
                     Description = "Ingresos",
                     Origin = "CR",
                     Status = true
                 },
                new AccountType
                {
                    ID = 5,
                    Description = "Costos",
                    Origin = "DB",
                    Status = true
                },
                new AccountType
                {
                    ID = 6,
                    Description = "Gastos",
                    Origin = "DB",
                    Status = true
                }
            );

            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType()
                {
                    ID = 1,
                    Description = "Peso",
                    LastExchangeRate = 1,
                    Status = true
                },
                new CurrencyType()
                {
                    ID = 2,
                    Description = "Dolar",
                    LastExchangeRate = 45.87,
                    Status = true
                },
                new CurrencyType()
                {
                    ID = 3,
                    Description = "Euro",
                    LastExchangeRate = 57.89,
                    Status = true
                }
                );

            modelBuilder.Entity<AuxiliarSystem>().HasData(
                new AuxiliarSystem()
                {
                    ID = 1,
                    Name = "Contabilidad",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 2,
                    Name = "Nomina",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 3,
                    Name = "Facturacion",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 4,
                    Name = "Inventario",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 5,
                    Name = "Cuentas X Cobrar",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 6,
                    Name = "Cuentas x Pagar",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 7,
                    Name = "Compras",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 8,
                    Name = "Activos Fijos",
                    State = true
                },
                new AuxiliarSystem()
                {
                    ID = 9,
                    Name = "Cheques",
                    State = true
                }
                );

            modelBuilder.Entity<AccountingAccount>().HasData(
                new AccountingAccount()
                {
                    ID = 1,
                    Description = "Activos",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 1,
                    Level = 1,
                    Balance = 0,
                },
                new AccountingAccount()
                {
                    ID = 2,
                    Description = "Efectivos en caja y banco",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 1,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 1
                },
                new AccountingAccount()
                {
                    ID = 3,
                    Description = "Caja Chica",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 1,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 2
                },
                new AccountingAccount()
                {
                    ID = 4,
                    Description = "Cuenta Corriente Banco X",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 1,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 3
                },
                new AccountingAccount()
                {
                    ID = 5,
                    Description = "Inventarios y Mercancias",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 1,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 1
                },
                new AccountingAccount()
                {
                    ID = 6,
                    Description = "Inventario",
                    Status = true,
                    IdAccountType = 1,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 5
                },
                new AccountingAccount()
                {
                    ID = 7,
                    Description = "Cuentas x Cobrar",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 1,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 1
                },
                new AccountingAccount()
                {
                    ID = 8,
                    Description = "Cuentas x Cobrar Cliente X",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 1,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 7

                },
                new AccountingAccount()
                {
                    ID = 12,
                    Description = "Ventas",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 4,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 9

                },
                new AccountingAccount()
                {
                    ID = 13,
                    Description = "Ingresos x Ventas",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 4,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 12


                },
                new AccountingAccount()
                {
                    ID = 47,
                    Description = "Gastos",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 6,
                    Level = 1,
                    Balance = 0,
                },
                new AccountingAccount()
                {
                    ID = 48,
                    Description = "Gastos Administrativos",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 6,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 47
                },
                new AccountingAccount()
                {
                    ID = 50,
                    Description = "Gastos Generales",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 6,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 48

                },
                new AccountingAccount()
                {
                    ID = 65,
                    Description = "Gasto depreciación Activos Fijos",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 6,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 47
                },
                new AccountingAccount()
                {
                    ID = 66,
                    Description = "Depreciación Acumulada Activos Fijos",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 6,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 65
                },
                new AccountingAccount()
                {
                    ID = 70,
                    Description = "Salarios y Sueldos Empleados",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 2,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 18
                },
                new AccountingAccount()
                {
                    ID = 71,
                    Description = "Gastos de Nomina Empresa",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 6,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 58
                },
                new AccountingAccount()
                {
                    ID = 80,
                    Description = "Compra de Mercancias",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 5,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 78
                },
                new AccountingAccount()
                {
                    ID = 81,
                    Description = "Cuentas x Pagar",
                    Status = true,
                    TransactionsEnabled = false,
                    IdAccountType = 2,
                    Level = 2,
                    Balance = 0,
                    MajorAccount = 19
                },
                new AccountingAccount()
                {
                    ID = 82,
                    Description = "Cuentas x Pagar Proveedor X",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 2,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 81
                },
                new AccountingAccount()
                {
                    ID = 83,
                    Description = "Cuentas Cheques en Banco X",
                    Status = true,
                    TransactionsEnabled = true,
                    IdAccountType = 1,
                    Level = 3,
                    Balance = 0,
                    MajorAccount = 3
                }
                );

        }
    }
}
