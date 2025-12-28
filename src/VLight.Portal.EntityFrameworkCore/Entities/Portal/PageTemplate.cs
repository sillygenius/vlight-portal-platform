// ================================
// Entities / Portal / PageTemplate.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Portal;


/// <summary>
/// 页面模板（门户核心）
/// </summary>
public class PageTemplate
{
    public Guid Id { get; set; }


    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// 页面配置 JSON（布局 + 组件）
    /// </summary>
    public string SchemaJson { get; set; } = string.Empty;


    /// <summary>
    /// 是否已发布
    /// </summary>
    public bool Published { get; set; }
}
