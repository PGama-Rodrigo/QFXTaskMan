using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class Project : BaseModel    
{
    public Project(string name, string description, DateTime? dueDate)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;
    }

    [Required(ErrorMessage = "{0} is required"), MaxLength(200, ErrorMessage = "{0} cannot be longer than 200 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required"), MaxLength(1000, ErrorMessage = "{0} cannot be longer than 1000 characters")]
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    
    // Foreign keys
    public Guid OrganizationId { get; set; }
    
    // Navigation properties
    public required Organization Organization { get; set; }
    public ICollection<ProjectUser>? Team { get; set; }

    public ICollection<Chore>? Chores { get; set; }
}