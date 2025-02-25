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