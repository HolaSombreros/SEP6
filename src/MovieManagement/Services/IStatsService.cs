namespace MovieManagement.Services;

public interface IStatsService
{
    Task<RatingDistributionByGenreModel> GetRatingDistributionByGenreAsync(int genreId);
}
