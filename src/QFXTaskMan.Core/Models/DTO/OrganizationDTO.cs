namespace QFXTaskMan.Core.Models.DTO;

public abstract class BaseOrganizationDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public sealed class OrganizationDTO : BaseOrganizationDTO
{

}

public sealed class CreateOrganizationDTO : BaseOrganizationDTO
{

}

public sealed class UpdateOrganizationDTO : BaseOrganizationDTO
{

}

public sealed class ListOrganizationDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
}