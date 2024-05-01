using Microsoft.AspNetCore.Mvc;

namespace CinePlus.Shared.Results;

public class ProblemDetailsResult : ProblemDetails
{
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public string? Url { get; set; }
}