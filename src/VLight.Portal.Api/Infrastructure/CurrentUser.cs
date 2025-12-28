using System.Security.Claims;
//using VLight.Portal.Application.Abstractions;
using VLight.Portal.Application.Contracts;


namespace VLight.Portal.Api.Infrastructure;


/// <summary>
/// 将 HttpContext 中的用户信息
/// 转换为 Application 层可用的 ICurrentUser
/// </summary>
public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;


    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    private ClaimsPrincipal User => _httpContextAccessor.HttpContext!.User;


    public string UserId =>
    User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;


    public string UserName =>
    User.Identity?.Name ?? string.Empty;


    public IEnumerable<string> Roles =>
    User.FindAll(ClaimTypes.Role).Select(r => r.Value);
}