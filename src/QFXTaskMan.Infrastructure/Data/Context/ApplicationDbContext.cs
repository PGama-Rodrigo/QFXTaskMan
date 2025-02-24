using Microsoft.EntityFrameworkCore;
using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Infrastructure.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Core.Models.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrganizationUser> OrganizationsUsers { get; set; }
    public DbSet<TaskUser> TasksUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}