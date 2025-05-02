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
            migrationBuilder.RenameColumn(
                name: "PurchaseInfo_purchaseNumber",
                table: "Tickets",
                newName: "PurchaseInfo_PurchaseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseInfo_PurchaseNumber",
                table: "Tickets",
                newName: "PurchaseInfo_purchaseNumber");
        }
    }
}
