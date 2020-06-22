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
                    UserName = "admin",
                    UserPassword = "admin",
                    UserRol = "Manager"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "agent",
                    UserPassword = "agent",
                    UserRol = "Agent"
                }
            );
        }
    }
}
