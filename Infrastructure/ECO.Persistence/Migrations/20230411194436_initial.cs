﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlusDesiCost = table.Column<int>(type: "int", nullable: false),
                    CarrierConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrierConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxDesi = table.Column<int>(type: "int", nullable: false),
                    MinDesi = table.Column<int>(type: "int", nullable: false),
                    CarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrierConfigurations_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrierReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrierReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrierReports_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDesi = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrierReports_CarrierId",
                table: "CarrierReports",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarrierId",
                table: "Orders",
                column: "CarrierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrierConfigurations");

            migrationBuilder.DropTable(
                name: "CarrierReports");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
