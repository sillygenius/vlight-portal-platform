// ================================
// DTOs / Portal / PageTemplateDto.cs
// ================================
namespace VLight.Portal.Application.DTOs.Portal;


/// <summary>
/// 门户页面模板 DTO
/// </summary>
public record PageTemplateDto(
    Guid Id,
    string Code,
    string Name,
    string SchemaJson
);
