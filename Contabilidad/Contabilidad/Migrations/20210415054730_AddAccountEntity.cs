using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Migrations
{
    public partial class AddAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "AccountingEntry");

            migrationBuilder.DropColumn(
                name: "SeatAmount",
                table: "AccountingEntry");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccountingAccount = table.Column<int>(type: "int", nullable: false),
                    IdAccountingEntry = table.Column<int>(type: "int", nullable: false),
                    CreditAmount = table.Column<double>(type: "float", nullable: false),
                    DebitAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountingAccount_IdAccountingAccount",
                        column: x => x.IdAccountingAccount,
                        principalTable: "AccountingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_AccountingEntry_IdAccountingEntry",
                        column: x => x.IdAccountingEntry,
                        principalTable: "AccountingEntry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IdAccountingAccount",
                table: "Account",
                column: "IdAccountingAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Account_IdAccountingEntry",
                table: "Account",
                column: "IdAccountingEntry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "AccountingEntry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SeatAmount",
                table: "AccountingEntry",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
