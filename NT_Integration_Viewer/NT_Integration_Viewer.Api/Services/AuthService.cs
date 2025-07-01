using Microsoft.Extensions.Options;

namespace NT_Integration_Viewer.Api.Services;

public class AuthOptions
{
    public UserCredentials Admin { get; set; } = new();
    public UserCredentials Viewer { get; set; } = new();
    public int SessionTimeoutMinutes { get; set; } = 30;
}

public class UserCredentials
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AuthService
{
    private readonly AuthOptions _options;
    private readonly IHttpContextAccessor _http;

    public AuthService(IOptions<AuthOptions> options, IHttpContextAccessor http)
    {
        _options = options.Value;
        _http = http;
    }

    public bool Login(string username, string password)
    {
        string role = "";
        if (username == _options.Admin.Username && password == _options.Admin.Password)
            role = "Admin";
        else if (username == _options.Viewer.Username && password == _options.Viewer.Password)
            role = "Viewer";
        else
            return false;

        _http.HttpContext!.Session.SetString("user", username);
        _http.HttpContext.Session.SetString("role", role);
        return true;
    }

    public void Logout()
    {
        _http.HttpContext?.Session.Clear();
    }

    public string? Role => _http.HttpContext?.Session.GetString("role");
}
