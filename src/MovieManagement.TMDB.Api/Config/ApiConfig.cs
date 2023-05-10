namespace MovieManagement.TMDB.Api.Config;
public class ApiConfig
{
    public static string Section { get; } = "ApiConfig";
    public static string? ImageUri { get; set; }
    public string? ApiKey { get; set; }
    public string? MovieDatabaseUri { get; set; }
    public string? MoviePath { get; set; }
    public string? UpcomingPath { get; set; }
    public string? CreditsPath { get; set; }
}