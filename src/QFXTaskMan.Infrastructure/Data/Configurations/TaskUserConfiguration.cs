using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public class TaskUserConfiguration : IEntityTypeConfiguration<TaskUser>
{
    public void Configure(EntityTypeBuilder<TaskUser> b)
    {
        b.ToTable("TasksUsers");

        // Primary key
        b.HasKey(tu => new { tu.TaskId, tu.UserId });

        // Relationships
        b.HasOne(tu => tu.Task)
            .WithMany(t => t.TaskMembers)
            .HasForeignKey(tu => tu.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(tu => tu.User)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(tu => tu.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}