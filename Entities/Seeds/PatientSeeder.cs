using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entities.Seeds
{
    public class PatientSeeder : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData
            (
                new Patient
                {
                    Id = 11,
                    Name = "Armando",
                    LastName = "Betancur",
                    DateOfBirth = new DateTime(1954, 03, 02),
                    Address = "La mota",
                    PhoneNumber = "310"
                },
                new Patient
                {
                    Id = 24,
                    Name = "Ana",
                    LastName = "Loaiza",
                    DateOfBirth = new DateTime(1955, 01, 06),
                    Address = "La mota",
                    PhoneNumber = "311"
                },
                new Patient
                {
                    Id = 71,
                    Name = "Diego",
                    LastName = "Betancur",
                    DateOfBirth = new DateTime(1985, 11, 09),
                    Address = "La mota",
                    PhoneNumber = "310"
                }
            );

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
