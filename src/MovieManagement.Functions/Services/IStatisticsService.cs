namespace MovieManagement.Functions.Services;

public interface IStatisticsService
{
    Task<RatingDistributionByGenreDto> Get(int genreId);
}