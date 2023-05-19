namespace MovieManagement.TMDB.Api.Services;

public interface IStatisticsService
{
    Task<MovieList> GetMostRatedMoviesByReleaseYear(int year, int page);
}