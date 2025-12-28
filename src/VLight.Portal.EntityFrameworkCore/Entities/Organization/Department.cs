// ================================
// Entities / Organization / Department.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Organization;


/// <summary>
/// 组织部门（树形结构）
/// </summary>
public class Department
{
    public Guid Id { get; set; }


    /// <summary>
    /// 父部门
    /// </summary>
    public Guid? ParentId { get; set; }


    public Department? Parent { get; set; }


    /// <summary>
    /// 部门编码
    /// </summary>
    public string Code { get; set; } = string.Empty;


    /// <summary>
    /// 部门名称
    /// </summary>
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// 排序号
    /// </summary>
    public int Sort { get; set; }


    public ICollection<Department> Children { get; set; } = new List<Department>();
}
