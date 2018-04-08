using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Stregelisten.Migrations
{
    public partial class AlteredModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcurementId",
                table: "Tabs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcurementId1",
                table: "Tabs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeverageId",
                table: "Procurements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_ProcurementId1",
                table: "Tabs",
                column: "ProcurementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Procurements_BeverageId",
                table: "Procurements",
                column: "BeverageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procurements_Beverages_BeverageId",
                table: "Procurements",
                column: "BeverageId",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Procurements_ProcurementId1",
                table: "Tabs",
                column: "ProcurementId1",
                principalTable: "Procurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procurements_Beverages_BeverageId",
                table: "Procurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Procurements_ProcurementId1",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_ProcurementId1",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Procurements_BeverageId",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "ProcurementId",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "ProcurementId1",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "BeverageId",
                table: "Procurements");
        }
    }
}
