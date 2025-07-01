using Microsoft.AspNetCore.Mvc;
using NT_Integration_Viewer.Api.Models;
using NT_Integration_Viewer.Api.Services;

namespace NT_Integration_Viewer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;

    public AuthController(AuthService auth) => _auth = auth;

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        if (_auth.Login(req.Username, req.Password))
            return Ok(new { role = _auth.Role });
        return Unauthorized();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        _auth.Logout();
        return Ok();
    }
}
