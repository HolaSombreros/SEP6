namespace MovieManagement.TMDB.Api.Config;
public class ApiConfig
{
    public static string Section { get; } = "ApiConfig";
    public string? APIKey { get; set; }
}