using Microsoft.AspNetCore.Mvc;
using NT_Integration_Viewer.Api.Models;
using NT_Integration_Viewer.Api.Services;

namespace NT_Integration_Viewer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ViewerController : ControllerBase
{
    private readonly ParserService _parser;

    public ViewerController(ParserService parser) => _parser = parser;

    [HttpPost("parse")]
    public IActionResult Parse([FromBody] ParseRequest req)
    {
        var parsed = _parser.Parse(req.Format, req.Message);
        return Ok(parsed);
    }
}
