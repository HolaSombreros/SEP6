namespace MovieManagement.Services
{
    public interface ICombinedRatingService
    {
        Task<MovieList> GetMovieListAsync(ListType listType, int page);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Credits> GetPersonCreditsAsync(int personId);
    }
}