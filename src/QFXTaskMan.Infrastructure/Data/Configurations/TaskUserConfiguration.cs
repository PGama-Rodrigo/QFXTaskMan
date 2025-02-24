using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Configurations;

public sealed class ChoreUserConfiguration : IEntityTypeConfiguration<ChoreUser>
{
    public void Configure(EntityTypeBuilder<ChoreUser> b)
    {
        b.ToTable("TasksUsers");

        // Primary key
        b.HasKey(tu => new { tu.ChoreId, tu.UserId });

        // Relationships
        b.HasOne(tu => tu.Chore)
            .WithMany(t => t.ChoreMembers)
            .HasForeignKey(tu => tu.ChoreId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(tu => tu.User)
            .WithMany(u => u.AssignedChores)
            .HasForeignKey(tu => tu.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}