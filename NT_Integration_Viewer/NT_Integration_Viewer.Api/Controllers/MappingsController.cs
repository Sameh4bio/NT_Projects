using Microsoft.AspNetCore.Mvc;
using NT_Integration_Viewer.Api.Services;

namespace NT_Integration_Viewer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MappingsController : ControllerBase
{
    private readonly MappingService _mappings;
    private readonly AuthService _auth;

    public MappingsController(MappingService mappings, AuthService auth)
    {
        _mappings = mappings;
        _auth = auth;
    }

    [HttpGet("load")]
    public async Task<IActionResult> Load([FromQuery] string format)
    {
        var map = await _mappings.LoadAsync(format);
        return Ok(map);
    }

    [HttpPost("save")]
    public async Task<IActionResult> Save([FromQuery] string format, [FromBody] Dictionary<string, object> data)
    {
        if (_auth.Role != "Admin") return Unauthorized();
        await _mappings.SaveAsync(format, data);
        return Ok();
    }
}
