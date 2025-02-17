using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Core.Models.Task>
{
    public void Configure(EntityTypeBuilder<Core.Models.Task> builder)
    {
        builder.ToTable("Tasks");

        // Primary key
        builder.HasKey(t => t.Id);

        // Properties
        builder.Property(t => t.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}