namespace NT_Integration_Viewer.Api.Models;

public class ParseRequest
{
    public string Format { get; set; } = "hl7";
    public string Message { get; set; } = string.Empty;
}
