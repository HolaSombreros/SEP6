namespace MovieManagement.Database.Repositories;

public interface IMovieRepository
{
    Task<MovieEntity?> AddMovieAsync(MovieEntity movie);
    Task<MovieEntity?> GetMovieByIdAsync(int id);
}