using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
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
        b.HasMany(u => u.OwnedProjects)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        b.HasIndex(u => u.Email)
            .IsUnique();

        b.HasIndex(u => u.Username)
            .IsUnique();
    }
}