using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace homework_2sem_2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotteries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberRange_Min = table.Column<int>(type: "integer", nullable: true),
                    NumberRange_Max = table.Column<int>(type: "integer", nullable: true),
                    NumberRange_NumbersPerTicket = table.Column<int>(type: "integer", nullable: true),
                    WinningCombination = table.Column<int[]>(type: "integer[]", nullable: false),
                    PrizeFund = table.Column<decimal>(type: "numeric", nullable: false),
                    DrawTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactInfo_Phone = table.Column<string>(type: "text", nullable: true),
                    ContactInfo_Email = table.Column<string>(type: "text", nullable: true),
                    ContactInfo_Address = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsWinning = table.Column<bool>(type: "boolean", nullable: false),
                    Numbers = table.Column<int[]>(type: "integer[]", nullable: false),
                    PurchaseInfo_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PurchaseInfo_purchaseNumber = table.Column<Guid>(type: "uuid", nullable: true),
                    LotteryId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Lotteries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lotteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Participants_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LotteryId",
                table: "Tickets",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Lotteries");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
