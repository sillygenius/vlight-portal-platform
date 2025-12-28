namespace VLight.Portal.Api.Models;


/// <summary>
/// 登录响应 DTO
/// </summary>
public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}
