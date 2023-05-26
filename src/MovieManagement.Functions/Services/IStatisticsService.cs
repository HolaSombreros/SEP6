namespace MovieManagement.Functions.Services;

public interface IStatisticsService
{
    Task<RatingDistributionByGenreDto> GetAsync(int genreId);
    Task<AgeDistributionInMovieDto> GetAgeDistributionAsync(int movieId);
    Task<GenderDistributionInMainRolesDto> GetGenderDistributionInMainRoles(int genreId);
}