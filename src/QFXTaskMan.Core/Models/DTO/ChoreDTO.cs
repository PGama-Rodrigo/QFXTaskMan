using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models.DTO;

public abstract class BaseChoreDTO : BaseDTO
{
    public Guid? ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ChorePriority Priority { get; set; }
    public ChoreStatus Status { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid ProjectId { get; set; }
}

public sealed class ChoreDTO : BaseChoreDTO
{

}

public sealed class CreateChoreDto : BaseChoreDTO
{

}

public sealed class UpdateChoreDto : BaseChoreDTO
{

}

public sealed class ListChoreDTO : BaseDTO
{
    public string Title { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public string Project { get; set; } = string.Empty;
    public string Parent { get; set; } = string.Empty;
}