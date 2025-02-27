using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
{
    public void Configure(EntityTypeBuilder<ProjectUser> b)
    {
        b.ToTable("TasksUsers");

        // Primary key
        b.HasKey(tu => new { tu.ProjectId, tu.UserId });

        // Relationships
        b.HasOne(tu => tu.Project)
            .WithMany(t => t.Team)
            .HasForeignKey(tu => tu.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(tu => tu.User)
            .WithMany(u => u.AssignedProjects)
            .HasForeignKey(tu => tu.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}