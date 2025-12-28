// ================================
// Entities / Authorization / Resource.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Authorization;


/// <summary>
/// 资源类型
/// </summary>
public enum ResourceType
{
    Menu,
    Page,
    Button,
    Indicator,
    Link,
    Document
}


/// <summary>
/// 系统统一资源模型（权限核心）
/// </summary>
public class Resource
{
    public Guid Id { get; set; }


    public Guid? ParentId { get; set; }
    public Resource? Parent { get; set; }


    /// <summary>
    /// 资源编码（唯一）
    /// </summary>
    public string Code { get; set; } = string.Empty;


    /// <summary>
    /// 显示名称
    /// </summary>
    public string Name { get; set; } = string.Empty;


    public ResourceType Type { get; set; }


    public int Sort { get; set; }
}
