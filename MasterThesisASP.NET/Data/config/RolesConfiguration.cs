using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterThesisASP.NET.Data;

public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    void IEntityTypeConfiguration<IdentityRole>.Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole{Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN"},
            new IdentityRole{Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER"}
        );
    }
}
