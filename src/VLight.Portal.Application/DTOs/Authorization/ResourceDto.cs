// ================================
// DTOs / Authorization / ResourceDto.cs
// ================================
namespace VLight.Portal.Application.DTOs.Authorization;


/// <summary>
/// 授权资源 DTO
/// </summary>
public record ResourceDto(
    Guid Id,
    string Code,
    string Name,
    string Type
);
