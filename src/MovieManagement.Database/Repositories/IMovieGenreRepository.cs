namespace MovieManagement.Database.Repositories;

public interface IMovieGenreRepository
{
    Task<MovieGenreEntity?> AddMovieGenreAsync(MovieGenreEntity movieGenre);
    Task<MovieGenreEntity?> GetMovieGenreAsync(int movieId, int genreId);
}