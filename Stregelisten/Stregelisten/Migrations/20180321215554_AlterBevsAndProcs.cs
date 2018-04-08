using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Stregelisten.Migrations
{
    public partial class AlterBevsAndProcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beverages_Procurements_ProcurementId",
                table: "Beverages");

            migrationBuilder.DropIndex(
                name: "IX_Beverages_ProcurementId",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "ProcurementId",
                table: "Beverages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcurementId",
                table: "Beverages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beverages_ProcurementId",
                table: "Beverages",
                column: "ProcurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beverages_Procurements_ProcurementId",
                table: "Beverages",
                column: "ProcurementId",
                principalTable: "Procurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
