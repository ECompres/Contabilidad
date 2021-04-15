using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LastExchangeRate",
                table: "CurrencyType",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorAccount",
                table: "AccountingAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "ID", "Description", "Origin", "Status" },
                values: new object[,]
                {
                    { 1, "Activos", "DB", true },
                    { 2, "Pasivos", "CR", true },
                    { 3, "Capital", "CR", true },
                    { 4, "Ingresos", "CR", true },
                    { 5, "Costos", "DB", true },
                    { 6, "Gastos", "DB", true }
                });

            migrationBuilder.InsertData(
                table: "AuxiliarSystem",
                columns: new[] { "ID", "Name", "State" },
                values: new object[,]
                {
                    { 9, "Cheques", true },
                    { 8, "Activos Fijos", true },
                    { 7, "Compras", true },
                    { 6, "Cuentas x Pagar", true },
                    { 3, "Facturacion", true },
                    { 4, "Inventario", true },
                    { 2, "Nomina", true },
                    { 1, "Contabilidad", true },
                    { 5, "Cuentas X Cobrar", true }
                });

            migrationBuilder.InsertData(
                table: "CurrencyType",
                columns: new[] { "ID", "Description", "LastExchangeRate", "Status" },
                values: new object[,]
                {
                    { 2, "Dolar", 45.869999999999997, true },
                    { 1, "Peso", 1.0, true },
                    { 3, "Euro", 57.890000000000001, true }
                });

            migrationBuilder.InsertData(
                table: "AccountingAccount",
                columns: new[] { "ID", "Balance", "Description", "IdAccountType", "Level", "MajorAccount", "Status", "TransactionsEnabled" },
                values: new object[,]
                {
                    { 1, 0.0, "Activos", 1, 1, 0, true, false },
                    { 65, 0.0, "Gasto depreciación Activos Fijos", 6, 2, 47, true, false },
                    { 50, 0.0, "Gastos Generales", 6, 3, 48, true, true },
                    { 48, 0.0, "Gastos Administrativos", 6, 2, 47, true, false },
                    { 47, 0.0, "Gastos", 6, 1, 0, true, false },
                    { 80, 0.0, "Compra de Mercancias", 5, 3, 78, true, true },
                    { 13, 0.0, "Ingresos x Ventas", 4, 3, 12, true, true },
                    { 12, 0.0, "Ventas", 4, 2, 9, true, false },
                    { 82, 0.0, "Cuentas x Pagar Proveedor X", 2, 3, 81, true, true },
                    { 66, 0.0, "Depreciación Acumulada Activos Fijos", 6, 3, 65, true, true },
                    { 81, 0.0, "Cuentas x Pagar", 2, 2, 19, true, false },
                    { 83, 0.0, "Cuentas Cheques en Banco X", 1, 3, 3, true, true },
                    { 8, 0.0, "Cuentas x Cobrar Cliente X", 1, 3, 7, true, true },
                    { 7, 0.0, "Cuentas x Cobrar", 1, 2, 1, true, false },
                    { 6, 0.0, "Inventario", 1, 3, 5, true, false },
                    { 5, 0.0, "Inventarios y Mercancias", 1, 2, 1, true, false },
                    { 4, 0.0, "Cuenta Corriente Banco X", 1, 3, 3, true, true },
                    { 3, 0.0, "Caja Chica", 1, 3, 2, true, true },
                    { 2, 0.0, "Efectivos en caja y banco", 1, 2, 1, true, false },
                    { 70, 0.0, "Salarios y Sueldos Empleados", 2, 3, 18, true, true },
                    { 71, 0.0, "Gastos de Nomina Empresa", 6, 3, 58, true, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AccountingAccount",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AuxiliarSystem",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CurrencyType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrencyType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrencyType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "LastExchangeRate",
                table: "CurrencyType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "MajorAccount",
                table: "AccountingAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
