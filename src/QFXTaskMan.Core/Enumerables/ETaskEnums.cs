namespace QFXTaskMan.Core.Enumerables;

/// <summary>
/// Represents the priority of a task.
/// </summary>
/// <remarks>
/// <list type="number">
/// <item>Low: The lowest priority of a task.</item>
/// <item>Medium: The second lowest priority of a task.</item>
/// <item>High: The middle priority of a task.</item>
/// <item>Critical: The highest priority of a task.</item>
/// </list>
/// </remarks>
public enum ChorePriority : byte
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}

/// <summary>
/// Represents the status of a task.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>ToDo: The task is not started yet.</item>
/// <item>PreReview: The task is in the pre-review stage.</item>
/// <item>InProgress: The task is in progress.</item>
/// <item>PostReview: The task is in the post-review stage.</item>
/// <item>Done: The task is completed.</item>
/// <item>Canceled: The task is canceled.</item>
/// </list>
/// </remarks>
public enum ChoreStatus : byte
{
    ToDo = 1,    
    PreReview = 2,
    InProgress = 3,
    PostReview = 4,
    Done = 8,
    Canceled = 9
}