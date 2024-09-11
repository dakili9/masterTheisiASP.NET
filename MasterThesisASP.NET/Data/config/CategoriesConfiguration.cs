namespace MasterThesisASP.NET.Data.config;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MasterThesisASP.NET.Models;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
    {
         builder.HasData(
            new Category
            {
                Id = Guid.Parse("8d3fd19b-07f0-4cae-9399-b404f45b3f58"),
                Name = "Work"
            },
            new Category
            {
                Id = Guid.Parse("062fedb0-b82e-4c6c-af1d-cf290a3f0d6c"),
                Name = "Personal"
            },
            new Category
            {
                Id = Guid.Parse("05164132-1320-4a6e-8184-2722acac7e0f"),
                Name = "Urgent"
            }
        );
    }
}
