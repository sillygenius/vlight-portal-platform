// ================================
// Entities / Portal / PortalApplication.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Portal;


/// <summary>
/// 门户接入应用
/// </summary>
public class PortalApplication
{
    public Guid Id { get; set; }


    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;


    public string? EntryUrl { get; set; }


    public bool Enabled { get; set; }
}
