namespace QFXTaskMan.Core.Models.DTO;

public abstract class BaseProjectDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public Guid OrganizationId { get; set; }
    public Guid OwnerId { get; set; }
}

public sealed class ProjectDTO : BaseProjectDTO
{
    public ICollection<ChoreDTO> Chores { get; set; } = [];
    public string Organization { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
}

public sealed class CreateProjectDTO : BaseProjectDTO
{

}

public sealed class UpdateProjectDTO : BaseProjectDTO
{

}

public sealed class ListProjectDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public string Organization { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
}