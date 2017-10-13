using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace rallyetimenetcoreapi.Migrations
{
    public partial class AddRacerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Checkpoints");

            migrationBuilder.DropColumn(
                name: "TimeActual",
                table: "Checkpoints");

            migrationBuilder.DropColumn(
                name: "TimeError",
                table: "Checkpoints");

            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "Checkpoints");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Checkpoints");

            migrationBuilder.DropColumn(
                name: "TimeTrue",
                table: "Checkpoints");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Driver = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Navigator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CheckpointId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true),
                    TimeActual = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TimeError = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeTrue = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSections_Checkpoints_CheckpointId",
                        column: x => x.CheckpointId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CarId",
                table: "CourseSections",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CheckpointId",
                table: "CourseSections",
                column: "CheckpointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Checkpoints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeActual",
                table: "Checkpoints",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeError",
                table: "Checkpoints",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeIn",
                table: "Checkpoints",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOut",
                table: "Checkpoints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeTrue",
                table: "Checkpoints",
                maxLength: 250,
                nullable: true);
        }
    }
}
