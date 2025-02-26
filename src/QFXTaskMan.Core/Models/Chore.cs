using System.ComponentModel.DataAnnotations;
using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public sealed class Chore : BaseModel
{
    public Guid? ParentId { get; set; }

    [Required(ErrorMessage = "{0} is required"), MaxLength(200, ErrorMessage = "{0} cannot be longer than 200 characters")]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ChorePriority Priority { get; set; }
    public ChoreStatus Status { get; set; }
    public DateTime? DueDate { get; set; }
    
    // Foreign keys
    public Guid ProjectId { get; set; }
    
    // Navigation properties
    public required Project Project { get; set; }
    public Chore? Parent { get; set; }
    public ICollection<Chore>? DetailTasks { get; set; }
    public ICollection<ChoreUser>? ChoreMembers { get; set; }

}