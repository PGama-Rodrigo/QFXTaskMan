using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Core.Models.Task>
{
    public void Configure(EntityTypeBuilder<Core.Models.Task> b)
    {
        b.ToTable("Tasks");

        // Primary key
        b.HasKey(t => t.Id);

        // Properties
        b.Property(t => t.Logs)
            .HasColumnType("nvarchar(max)");

        // Relationships
        b.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(t => t.TaskMembers)
            .WithOne(tu => tu.Task)
            .HasForeignKey(tu => tu.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(t => t.Parent)
            .WithMany(u => u.DetailTasks)
            .HasForeignKey(t => t.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}