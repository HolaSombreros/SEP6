namespace MovieManagement.Functions.Services;

public interface IMovieGenreService
{
    Task<MovieGenreDto> GetMovieGenreAsync(int movieId, int genreId);
    Task<IList<MovieGenreDto>> AddMovieGenreAsync(IList<GenreDto> genres, int movieId);
}