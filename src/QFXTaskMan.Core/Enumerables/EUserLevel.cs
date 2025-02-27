namespace QFXTaskMan.Core.Enumerables;

/// <summary>
/// Represents the user level in an organization.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>From Intern to Senior, each user can only see the projects and tasks that were been assigned to them.</item>
/// <item>Leads can see all tasks and projects from intern to senior.</item>
/// <item>Managers can see all tasks and projects from intern to lead.</item>
/// <item>Directors can see all tasks and projects from intern to manager.</item>
/// <item>Executives can see all tasks and projects from intern to director.</item>
/// <item>Admins can see all tasks and projects from intern to executive.</item>
/// </list>
/// <item>List of user levels:</item>
/// <list type="number">
/// <item>Application: No access. Waiting for approval from a Manager or above to get into the organization.</item>
/// <item>Intern: The lowest level of the organization.</item>
/// <item>Junior: The second lowest level of the organization.</item>
/// <item>Mid: The middle level of the organization.</item>
/// <item>Senior: The second highest level of the organization.</item>
/// <item>Lead: The highest level of the organization.</item>
/// <item>Manager: The manager level of the organization.</item>
/// <item>Director: The director level of the organization.</item>
/// <item>Executive: The executive level of the organization.</item>
/// <item>Admin: The highest level of the organization, can do anything.</item>
/// </list>
/// </remarks>
public enum EOrganizationUserLevel : byte
{
    Application = 0,
    Intern = 1,
    Junior = 2,
    Mid = 3,
    Senior = 4,
    Lead = 5,
    Manager = 6,
    Director = 7,
    Executive = 8,
    Admin = 9
}

/// <summary>
/// Represents the user level in a project or task.
/// </summary>
/// <remarks>
/// <list type="number">
/// <item>Members can only see the tasks that were been assigned to them.</item>
/// <item>Leads can see all tasks from members.</item>
/// <item>Managers can see all tasks from members and leads.</item>
/// </list>
/// </remarks>
public enum ETaskUserLevel : byte
{
    Member = 1,
    Lead = 2,
    Manager = 3,
}