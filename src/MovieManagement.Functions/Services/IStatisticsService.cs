namespace MovieManagement.Functions.Services;

public interface IStatisticsService
{
    Task<RatingDistributionByGenreDto> GetAsync(int genreId);
    Task<AgeDistributionInMovieDto> GetAgeDistributionAsync(int movieId);
    Task<Dictionary<string, int>> GetGenderDistributionInMainRoles(int genreId);
}