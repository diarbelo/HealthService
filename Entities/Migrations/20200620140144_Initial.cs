using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AppointmentType = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_appointment_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "PatientId", "Address", "DateOfBirth", "LastName", "Name", "PhoneNumber" },
                values: new object[] { 11, "La mota", new DateTime(1954, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betancur", "Armando", "310" });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "PatientId", "Address", "DateOfBirth", "LastName", "Name", "PhoneNumber" },
                values: new object[] { 24, "La mota", new DateTime(1955, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loaiza", "Ana", "311" });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "PatientId", "Address", "DateOfBirth", "LastName", "Name", "PhoneNumber" },
                values: new object[] { 71, "La mota", new DateTime(1985, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betancur", "Diego", "310" });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PatientId",
                table: "appointment",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
