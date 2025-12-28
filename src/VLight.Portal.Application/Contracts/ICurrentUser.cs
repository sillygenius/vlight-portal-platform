// ================================
// Contracts / ICurrentUser.cs
// ================================
namespace VLight.Portal.Application.Contracts;


/// <summary>
/// 当前登录用户上下文抽象
/// Api 层负责实现，Application 层只消费
/// </summary>
public interface ICurrentUser
{
    string UserId { get; }
    string UserName { get; }
    IEnumerable<string> Roles { get; }
}
