﻿namespace MovieManagement.Config;

public class AzureFunctionsConfig
{
    public const string Section = "AzureFunctionsConfig";
    public string AzureFunctionUri { get; set; } = default!;
    public string HostKey { get; set; } = default!;
    public string RegisterUserPath { get; set; } = default!;
    public string LoginUserPath { get; set; } = default!;
    public string UpdateUserPath { get; set; } = default!;
    public string DeleteUserPath { get; set; } = default!;
    public string RateMoviePath { get; set; } = default!;
    public string GetMovieRatings { get; set; } = default!;
    public string GetMovieRatingsByIdsPath { get; set; } = default!;
    public string QueryBuilder { get; set; } = default!;
    public string AndQueryBuilder { get; set; } = default!;
}