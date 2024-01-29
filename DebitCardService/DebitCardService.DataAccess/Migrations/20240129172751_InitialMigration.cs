using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebitCardService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DebitCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv2Code = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveCashWithdrawal = table.Column<bool>(type: "bit", nullable: false),
                    CashWithdrawalLimit = table.Column<int>(type: "int", nullable: false),
                    IsActiveByPayPass = table.Column<bool>(type: "bit", nullable: false),
                    PayPassLimit = table.Column<int>(type: "int", nullable: false),
                    IsActiveByPhone = table.Column<bool>(type: "bit", nullable: false),
                    PhoneLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitCards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebitCards");
        }
    }
}
