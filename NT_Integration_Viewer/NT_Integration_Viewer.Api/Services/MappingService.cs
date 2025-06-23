using System.Text.Json;

namespace NT_Integration_Viewer.Api.Services;

public class MappingService
{
    private readonly IWebHostEnvironment _env;
    public MappingService(IWebHostEnvironment env) => _env = env;

    public async Task<Dictionary<string, object>> LoadAsync(string format)
    {
        var path = Path.Combine(_env.ContentRootPath, "mappings", $"{format}_mapping.json");
        if (!File.Exists(path)) return new();
        var json = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new();
    }

    public async Task SaveAsync(string format, Dictionary<string, object> data)
    {
        var path = Path.Combine(_env.ContentRootPath, "mappings", $"{format}_mapping.json");
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(path, json);
    }
}
