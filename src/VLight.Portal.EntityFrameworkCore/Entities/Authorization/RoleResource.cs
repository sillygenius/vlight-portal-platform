// ================================
// Entities / Authorization / RoleResource.cs
// ================================
using Microsoft.AspNetCore.Identity;


namespace VLight.Portal.EntityFrameworkCore.Entities.Authorization;


/// <summary>
/// 角色 - 资源 授权关系
/// </summary>
public class RoleResource
{
    public string RoleId { get; set; } = string.Empty;
    public IdentityRole? Role { get; set; }


    public Guid ResourceId { get; set; }
    public Resource? Resource { get; set; }
}
