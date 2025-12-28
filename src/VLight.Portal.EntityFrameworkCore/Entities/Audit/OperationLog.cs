// ================================
// Entities / Audit / OperationLog.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Audit;


/// <summary>
/// 操作审计日志
/// </summary>
public class OperationLog
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = string.Empty;


    public string Action { get; set; } = string.Empty;
    public DateTime Time { get; set; }
}
