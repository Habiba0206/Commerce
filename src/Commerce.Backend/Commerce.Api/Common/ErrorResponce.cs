namespace Commerce.Api.Common;

public class ErrorResponse
{
    public string Error { get; set; } = default!;
    public List<string>? Details { get; set; }
}

