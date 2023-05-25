namespace MovieManagement.Services
{
    public interface ICombinedRatingService
    {
        Task<MovieList> GetMovieListAsync(ListType listType, int page);
        Task<MovieList> GetMoviesWithHighestRevenue(int year, int page);
        Task<MovieList> GetMoviesWithHighestRating(int year, int page);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Credits> GetPersonCreditsAsync(int personId);
    }
}