using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMarketApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Vin = table.Column<string>(type: "text", nullable: false),
                    SaleDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SaleCustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReservationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReservationCustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReservationExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Vin);
                    table.ForeignKey(
                        name: "FK_Cars_Customers_ReservationCustomerId",
                        column: x => x.ReservationCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Customers_SaleCustomerId",
                        column: x => x.SaleCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ReservationCustomerId",
                table: "Cars",
                column: "ReservationCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SaleCustomerId",
                table: "Cars",
                column: "SaleCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
