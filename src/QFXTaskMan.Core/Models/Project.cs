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

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    
    // Foreign keys
    public Guid OwnerId { get; set; }
    
    // Navigation properties
    public required User Owner { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}