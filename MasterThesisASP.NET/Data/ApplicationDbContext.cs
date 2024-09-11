using MasterThesisASP.NET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = MasterThesisASP.NET.Models.Task;

namespace MasterThesisASP.NET.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {

    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(builder =>{
            builder.HasKey(u=>u.Id);

            builder.HasMany(u => u.Tasks)
               .WithOne(t => t.User)
               .HasForeignKey(t => t.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Task>(builder =>{

            builder.HasKey(t=>t.Id);

            builder.Property(t => t.Status)
            .HasConversion<string>();

             builder.HasOne(t => t.User)
               .WithMany(u => u.Tasks)
               .HasForeignKey(t => t.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Category)
               .WithMany(c => c.Tasks)
               .HasForeignKey(t => t.CategoryId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Category>(builder =>
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Tasks)
               .WithOne(t => t.Category)
               .HasForeignKey(t => t.CategoryId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        });

        
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);    
    }
}
