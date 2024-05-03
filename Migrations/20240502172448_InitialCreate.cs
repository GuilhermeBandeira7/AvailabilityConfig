using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvailabilityConfig.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ip = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Direction = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Highway = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Parents = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LATLNG = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    KmComplement = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastVerification = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Value = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    PingTime = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    PingsToOffline = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VerificationTime = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    currentStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CameraId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configs_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configs_CameraId",
                table: "Configs",
                column: "CameraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Cameras");
        }
    }
}
