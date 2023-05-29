namespace MovieManagement.Services;

public class StatsService : IStatsService
{
    private readonly IAzureService service;
    private readonly AzureFunctionsConfig settings;

    public StatsService(IAzureService service, IOptions<AzureFunctionsConfig> settings)
    {
        this.service = service;
        this.settings = settings.Value;
    }

    public async Task<RatingDistributionByGenreModel> GetRatingDistributionByGenreAsync(int genreId)
    {
        var dto = await service.GetFromRouteAsync<RatingDistributionByGenreDto>(settings.RatingDistributionByGenrePath, genreId);
        return new RatingDistributionByGenreModel(dto);
    }
    
    public async Task<AgeDistributionModel> GetAgeDistributionAsync(int movieId)
    {
        var dto = await service.GetFromRouteAsync<AgeDistributionInMovieDto>(settings.DistributionOfAgeInAMovie, movieId);
        return new AgeDistributionModel(dto);
    }
}
