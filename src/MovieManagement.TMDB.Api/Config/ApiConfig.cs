namespace MovieManagement.TMDB.Api.Config;
public class ApiConfig
{
    public static string Section { get; } = "ApiConfig";
    public static string ImageUri { get; set; } = default!;
    public string ApiKey { get; set; } = default!;
    public string MovieDatabaseUri { get; set; } = default!;
    public string MoviePath { get; set; } = default!;
    public string UpcomingPath { get; set; } = default!;
    public string CreditsPath { get; set; } = default!;
    public string PopularPath { get; set; } = default!;
    public string PagePath { get; set; } = default!;
    public string TopRatedPath { get; set; } = default!;
    public string InTheatrePath { get; set; } = default!;
    public string QueryBuilder { get; set; } = default!;
    public string AndQueryBuilder { get; set; } = default!;
}