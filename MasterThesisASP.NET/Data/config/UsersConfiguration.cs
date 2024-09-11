using System;
using MasterThesisASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MasterThesisASP.NET.Data.config;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = Guid.Parse("c3fd4f55-22d5-4ed4-befc-9b5e2c0c4c6a"),
                UserName = "pera.peric",
                NormalizedUserName = "PERA.PERIC",
                Email = "pera.peric@example.com",
                NormalizedEmail = "PERA.PERIC@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = new Microsoft.AspNetCore.Identity.PasswordHasher<User>().HashPassword(new User(), "password"),
                IsAdmin = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            },
            new User
            {
                Id = Guid.Parse("f8d447e3-3183-40ff-9b71-7d9f60d4ad98"),
                UserName = "mika.mikic",
                NormalizedUserName = "MIKA.MIKIC",
                Email = "mika.mikic@example.com",
                NormalizedEmail = "MIKA.MIKIC@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = new Microsoft.AspNetCore.Identity.PasswordHasher<User>().HashPassword(new User(), "password"),
                IsAdmin = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            }
        );
    }
}
