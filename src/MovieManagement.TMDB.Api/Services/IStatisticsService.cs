namespace MovieManagement.TMDB.Api.Services;

public interface IStatisticsService
{
    Task<MovieList> GetMostRatedMoviesByReleaseYearAsync(int year, int page);
    Task<MovieList> GetMoviesWithHighestRevenueByYearAsync(int year, int page);
    Task<Credits> GetMostPopularMovieAsync(int personId);
}