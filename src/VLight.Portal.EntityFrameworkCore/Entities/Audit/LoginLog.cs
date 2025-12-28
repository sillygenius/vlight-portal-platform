// ================================
// Entities / Audit / LoginLog.cs
// ================================
namespace VLight.Portal.EntityFrameworkCore.Entities.Audit;


/// <summary>
/// 登录日志
/// </summary>
public class LoginLog
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = string.Empty;


    public DateTime LoginTime { get; set; }
    public string IpAddress { get; set; } = string.Empty;
}
