using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> b)
    {
        b.ToTable("Projects");

        // Primary key
        b.HasKey(p => p.Id);

        // Properties
        b.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        b.Property(p => p.Description)
            .HasMaxLength(1000);

        b.Property(p => p.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        b.HasOne(p => p.Owner)
            .WithMany(u => u.OwnedProjects)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}