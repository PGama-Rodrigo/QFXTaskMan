namespace QFXTaskMan.Core.Models.DTO;

public abstract class BaseDTO
{
    public Guid? Id { get; set; }
}

public sealed class SelectDTO 
{
    public string Value { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string DefaultValue { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public bool Disabled { get; set; } = false;
}

/// <summary>
/// DTO to filter activities (Logs)
/// </summary>
/// <remarks>
/// Every property is nullable, so you can filter by one or more properties.
/// <list type="bullet">
/// <item>OrganizationId: The ID of the Organization. This is the only filter that operates in single selection.</item>
/// <item>UserId: The List of User IDs.</item>
/// <item>ProjectId: The List of Project IDs.</item>
/// <item>TaskId: The List of Task IDs.</item>
/// <item>FromDate: The List of From Dates. This filter operates within the ToDate to filter ranges of Dates.</item>
/// <item>ToDate: The List of To Dates. This filter operates within the FromDate to filter ranges of Dates.</item>
/// <item>Action: The List of Actions.</item>
/// </list>
/// The Dates will operate as a range, so they will have the same length. EXCEPT if it is only one date, then one of them can be ignored.
/// </remarks>
public sealed class ActivityFiltersDTO 
{
    public Guid? OrganizationId { get; set; }
    public ICollection<Guid>? UserId { get; set; }
    public ICollection<Guid>? ProjectId { get; set; }
    public ICollection<Guid>? TaskId { get; set; }
    public ICollection<DateTime>? FromDate { get; set; }
    public ICollection<DateTime>? ToDate { get; set; }
    public ICollection<Enumerables.ELogAction>? Action { get; set; }
}