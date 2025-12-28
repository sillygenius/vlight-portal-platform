// ================================
// Entities / Identity / ApplicationUser.cs
// ================================
using Microsoft.AspNetCore.Identity;


namespace VLight.Portal.EntityFrameworkCore.Entities.Identity;


/// <summary>
/// 系统用户实体
/// 继承 IdentityUser，用于 ASP.NET Core Identity
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// 显示名称（中文名 / 昵称）
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;


    /// <summary>
    /// 工号（对接电厂人事系统）
    /// </summary>
    public string? EmployeeNo { get; set; }


    /// <summary>
    /// 是否外部用户
    /// </summary>
    public bool IsExternal { get; set; }


    /// <summary>
    /// 所属部门
    /// </summary>
    public Guid? DepartmentId { get; set; }
    public Organization.Department? Department { get; set; }
}
