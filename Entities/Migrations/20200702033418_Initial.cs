﻿using System;
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
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    UserMail = table.Column<string>(maxLength: 80, nullable: false),
                    UserPassword = table.Column<string>(nullable: false),
                    UserRol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                    table.UniqueConstraint("AK_Mail", x => x.UserMail);
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
                values: new object[,]
                {
                    { 11, "La mota", new DateTime(1954, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betancur", "Armando", "310" },
                    { 24, "La mota", new DateTime(1955, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loaiza", "Ana", "311" },
                    { 71, "La mota", new DateTime(1985, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betancur", "Diego", "310" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "UserMail", "UserName", "UserPassword", "UserRol" },
                values: new object[,]
                {
                    { new Guid("c1031618-0e87-4ede-8020-7c70c2b4054c"), "admin@mail.com", "Diego", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "Manager" },
                    { new Guid("a8021c00-d37a-4465-abc2-497988b97784"), "agent@mail.com", "Armando", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "Agent" }
                });

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
                name: "user");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
