// ================================
// DTOs / Identity / UserDto.cs
// ================================
namespace VLight.Portal.Application.DTOs.Identity;


/// <summary>
/// 用户信息 DTO（给前端使用）
/// </summary>
public record UserDto(
    string Id,
    string UserName,
    string DisplayName,
    string? DepartmentName
);
