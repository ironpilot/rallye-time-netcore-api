using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace rallyetimenetcoreapi.Migrations
{
    public partial class AddRaceToCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RaceId",
                table: "Cars",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Races_RaceId",
                table: "Cars",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Races_RaceId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RaceId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Cars");
        }
    }
}
