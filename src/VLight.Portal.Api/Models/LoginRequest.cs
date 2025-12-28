namespace VLight.Portal.Api.Models;


/// <summary>
/// 登录请求 DTO
/// </summary>
public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}