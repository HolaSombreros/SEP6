namespace MovieManagement.Config;

public class AzureFunctionsConfig
{
    public const string Section = "AzureFunctionsConfig";
    public string AzureFunctionUri { get; set; } = default!;
    public string HostKey { get; set; } = default!;
    public string RegisterUserPath { get; set; } = default!;
    public string LoginUserPath { get; set; } = default!;
    public string UpdateUserPath { get; set; } = default!;
    public string DeleteUserPath { get; set; } = default!;
    public string CreateCustomList { get; set; } = default!;
    public string DeleteCustomList { get; set; } = default!;
    public string GetCustomLists { get; set; } = default!;
    public string AddToCustomList { get; set; } = default!;
    public string DeleteFromCustomList { get; set; } = default!;
    public string RateMoviePath { get; set; } = default!;
    public string GetMovieRatings { get; set; } = default!;
    public string GetMovieRatingsByIdsPath { get; set; } = default!;
    public string QueryBuilder { get; set; } = default!;
    public string AndQueryBuilder { get; set; } = default!;
    public string PagePath { get; set; } = default!;
    public string DeleteReviewPath { get; set; } = default!;
    public string GetMovieRating { get; set; } = default!;
}