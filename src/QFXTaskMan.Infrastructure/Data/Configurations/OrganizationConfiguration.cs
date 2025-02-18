using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> b)
    {
        b.ToTable("Organizations");

        // Primary key
        b.HasKey(o => o.Id);

        // Properties
        b.Property(o => o.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        b.HasMany(o => o.Projects)
            .WithOne(u => u.Organization)
            .HasForeignKey(o => o.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}