﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoT_REST_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureSensor",
                columns: table => new
                {
                    TemperatureSensorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceName = table.Column<string>(nullable: false),
                    DeviceModel = table.Column<string>(nullable: false),
                    LocationName = table.Column<string>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureSensor", x => x.TemperatureSensorId);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemperatureSensorId = table.Column<long>(nullable: false),
                    Temperature = table.Column<int>(nullable: false),
                    MeasureDate = table.Column<string>(nullable: false),
                    MeasureTime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_Measurement_TemperatureSensor_TemperatureSensorId",
                        column: x => x.TemperatureSensorId,
                        principalTable: "TemperatureSensor",
                        principalColumn: "TemperatureSensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_TemperatureSensorId",
                table: "Measurement",
                column: "TemperatureSensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "TemperatureSensor");
        }
    }
}
