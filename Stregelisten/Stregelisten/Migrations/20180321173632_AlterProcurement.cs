using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Stregelisten.Migrations
{
    public partial class AlterProcurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procurements_Beverages_BeverageId",
                table: "Procurements");

            migrationBuilder.DropIndex(
                name: "IX_Procurements_BeverageId",
                table: "Procurements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
