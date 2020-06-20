using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class SeedingPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "PatientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "PatientId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "PatientId",
                keyValue: 71);
        }
    }
}
