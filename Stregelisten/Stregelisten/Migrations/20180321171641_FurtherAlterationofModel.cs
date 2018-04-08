using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Stregelisten.Migrations
{
    public partial class FurtherAlterationofModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Procurements_ProcurementId1",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_ProcurementId1",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "ProcurementId1",
                table: "Tabs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcurementId1",
                table: "Tabs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_ProcurementId1",
                table: "Tabs",
                column: "ProcurementId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Procurements_ProcurementId1",
                table: "Tabs",
                column: "ProcurementId1",
                principalTable: "Procurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
