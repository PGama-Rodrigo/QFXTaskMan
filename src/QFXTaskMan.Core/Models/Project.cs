using System.ComponentModel.DataAnnotations;

namespace QFXTaskMan.Core.Models;

public sealed class Project : BaseClass    
{
    public Project(string name, string description, DateTime? dueDate, Guid ownerId)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;
        OwnerId = ownerId;
    }

    [Required(ErrorMessage = "{0} is required"), MaxLength(200, ErrorMessage = "{0} cannot be longer than 200 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} is required"), MaxLength(1000, ErrorMessage = "{0} cannot be longer than 1000 characters")]
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    
    // Foreign keys
    public Guid OwnerId { get; set; }
    
    // Navigation properties
    public required User Owner { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}