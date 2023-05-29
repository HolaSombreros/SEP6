namespace MovieManagement.Services;

public interface IStatsService
{
    Task<RatingDistributionByGenreModel> GetRatingDistributionByGenreAsync(int genreId);
    Task<AgeDistributionModel> GetAgeDistributionAsync(int movieId);
    Task<GenderDistributionModel> GetGenderDistributionAsync(int genreId);
}
