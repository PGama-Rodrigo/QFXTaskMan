using Microsoft.EntityFrameworkCore;
using QFXTaskMan.Core.Models;

public class TaskManagementDbContext : DbContext
{
    public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<QFXTaskMan.Core.Models.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrganizationUser> OrganizationsUsers { get; set; }    
    public DbSet<TaskUser> TasksUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure User entity
        modelBuilder.Entity<User>()
            .HasMany(u => u.OwnedProjects)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Configure Project entity
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Configure Task entity
        modelBuilder.Entity<QFXTaskMan.Core.Models.Task>()
            .Property(t => t.Status)
            .HasConversion<string>();
            
        modelBuilder.Entity<QFXTaskMan.Core.Models.Task>()
            .Property(t => t.Priority)
            .HasConversion<string>();
    }
}