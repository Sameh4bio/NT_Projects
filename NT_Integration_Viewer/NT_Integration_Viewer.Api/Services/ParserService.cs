using System.Text.Json;
using System.Xml.Linq;

namespace NT_Integration_Viewer.Api.Services;

public class ParserService
{
    public object Parse(string format, string message)
    {
        return format.ToLower() switch
        {
            "hl7" => ParseHl7(message),
            "json" => JsonSerializer.Deserialize<object>(message) ?? new(),
            "xml" => XElement.Parse(message),
            "fhir" => JsonSerializer.Deserialize<object>(message) ?? new(),
            _ => message
        };
    }

    private object ParseHl7(string message)
    {
        var segments = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var result = new List<Dictionary<string, string[]>>();
        foreach (var segment in segments)
        {
            var parts = segment.Split('|');
            result.Add(new Dictionary<string, string[]> { { parts[0], parts.Skip(1).ToArray() } });
        }
        return result;
    }
}
