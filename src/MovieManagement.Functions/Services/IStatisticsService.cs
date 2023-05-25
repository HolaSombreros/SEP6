namespace MovieManagement.Functions.Services;

public interface IStatisticsService
{
    Task<RatingDistributionByGenreDto> GetAsync(int genreId);
}