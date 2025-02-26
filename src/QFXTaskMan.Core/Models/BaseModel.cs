using System.Text.Json;
using QFXTaskMan.Core.Enumerables;

namespace QFXTaskMan.Core.Models;

public abstract class BaseModel
{
    public Guid Id { get; set; } = new Guid();        
    public bool Deleted { get; set; } = false;
    public string Logs { get; set; } = string.Empty;

    public List<Log> GetLogs()
    {
        return string.IsNullOrEmpty(Logs) ? 
            new List<Log>() : 
            JsonSerializer.Deserialize<List<Log>>(Logs)!;
    }

    public void AddLog(Log log)
    {
        var logs = GetLogs();
        logs.Add(log);
        Logs = JsonSerializer.Serialize(logs);
    }
}

/// <summary>
/// Log class to store changes in the database
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>When creating data, the WhatBefore will be empty and WhatAfter will be the new data.</item>
/// <item>When updating data (Thats include when the Deleted attribute is changed to true), the WhatBefore will be the old data and WhatAfter will be the new data.</item>
/// <item>This enviroment DOES NOT support deleting data, so the Deleted attribute will be used to mark the data as deleted.</item>
/// </list>
/// <para>Example:</para>
/// <example>
/// <code>
/// var log = new Log
/// {
///    WhoId = user.Id,
///    Action = ELogAction.Create,
///    WhatBefore = string.Empty,
///    WhatAfter = JsonSerializer.Serialize(new { Name = "John Doe" })
///    When = DateTime.Now
/// };
/// </code>
/// </example> 
/// Related: <seealso cref="ObjectComparer"/>
/// </remarks>
public class Log
{
    // Which User did this action (ID)
    public Guid WhoId { get; set; }

    public ELogAction Action { get; set; }

    // What did they do
    public DateTime When { get; set; } = DateTime.Now;
    
    // How it looks before (JSON)
    public string WhatBefore { get; set; } = string.Empty;

    // How it looks after (JSON)
    public string WhatAfter { get; set; } = string.Empty;

    // Which User did this action (Object)
    public required User Who { get; set; }
}