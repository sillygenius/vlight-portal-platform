// ================================
// Entities / Portal / RolePageTemplate.cs
// ================================
using Microsoft.AspNetCore.Identity;


namespace VLight.Portal.EntityFrameworkCore.Entities.Portal;


/// <summary>
/// 角色 -> 页面模板 映射
/// </summary>
public class RolePageTemplate
{
    public string RoleId { get; set; } = string.Empty;
    public IdentityRole? Role { get; set; }


    public Guid PageTemplateId { get; set; }
    public PageTemplate? PageTemplate { get; set; }
}
