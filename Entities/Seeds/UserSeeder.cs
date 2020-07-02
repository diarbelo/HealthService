using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Seeds
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "Diego",
                    UserMail = "admin@mail.com",
                    UserPassword = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    UserRol = "Manager"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "Armando",
                    UserMail = "agent@mail.com",
                    UserPassword = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824",
                    UserRol = "Agent"
                }
            );
        }
    }
}
