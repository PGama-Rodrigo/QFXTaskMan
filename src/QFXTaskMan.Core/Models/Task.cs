using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public class Task : BaseClass
{
    public Guid? ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public Enumerables.TaskStatus Status { get; set; }
    public DateTime? DueDate { get; set; }
    
    // Foreign keys
    public Guid ProjectId { get; set; }
    public Guid AssignedToId { get; set; }
    
    // Navigation properties
    public required Project Project { get; set; }
    public ICollection<Task>? DetailTasks { get; set; }
    public ICollection<TaskUser>? TaskMembers { get; set; }

}