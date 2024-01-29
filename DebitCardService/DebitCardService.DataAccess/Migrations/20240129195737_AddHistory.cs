using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebitCardService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DebitCards",
                type: "decimal(17,2)",
                precision: 17,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitCardId = table.Column<int>(type: "int", nullable: false),
                    DateOfOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    SenderAccountNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    RecipientAccountNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_DebitCards_DebitCardId",
                        column: x => x.DebitCardId,
                        principalTable: "DebitCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_DebitCardId",
                table: "History",
                column: "DebitCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "DebitCards",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(17,2)",
                oldPrecision: 17,
                oldScale: 2);
        }
    }
}
