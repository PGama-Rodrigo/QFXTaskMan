using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");

        // Primary key
        builder.HasKey(o => o.Id);

        // Properties
        builder.Property(o => o.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        builder.HasOne(o => o.Owner)
            .WithMany(u => u.OwnedOrganizations)
            .HasForeignKey(o => o.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Projects)
            .WithOne(u => u.Organization)
            .HasForeignKey(o => o.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}