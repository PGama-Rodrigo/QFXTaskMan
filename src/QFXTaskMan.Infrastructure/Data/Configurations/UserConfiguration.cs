using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("Users");

        // Primary key
        b.HasKey(u => u.Id);

        // Properties
        b.Property(u => u.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        b.HasMany(u => u.AssignedProjects)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(u => u.Organizations)
            .WithOne(ou => ou.User)
            .HasForeignKey(ou => ou.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        b.HasIndex(u => u.Email)
            .IsUnique();
    }
}