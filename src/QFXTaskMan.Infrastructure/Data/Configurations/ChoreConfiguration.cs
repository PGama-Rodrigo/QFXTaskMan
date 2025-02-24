using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class ChoreConfiguration : IEntityTypeConfiguration<Chore>
{
    public void Configure(EntityTypeBuilder<Chore> b)
    {
        b.ToTable("Tasks");

        // Primary key
        b.HasKey(t => t.Id);

        // Properties
        b.Property(t => t.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        b.HasOne(t => t.Project)
            .WithMany(p => p.Chores)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(t => t.ChoreMembers)
            .WithOne(tu => tu.Chore)
            .HasForeignKey(tu => tu.ChoreId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(t => t.Parent)
            .WithMany(u => u.DetailTasks)
            .HasForeignKey(t => t.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}