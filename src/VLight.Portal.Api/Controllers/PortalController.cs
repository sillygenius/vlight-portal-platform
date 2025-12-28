using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VLight.Portal.Application.Services;


namespace VLight.Portal.Api.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PortalController : ControllerBase
{
    private readonly PortalService _portalService;


    public PortalController(PortalService portalService)
    {
        _portalService = portalService;
    }


    [HttpGet("home")]
    public async Task<IActionResult> GetHome()
    {
        var result = await _portalService.GetPortalHomeAsync();
        return Ok(result);
    }
}
