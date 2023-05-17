namespace MovieManagement.Database.Repositories;

public interface IMovieRepository
{
    Task<MovieEntity?> AddMovie(MovieEntity movie);
    Task<MovieEntity?> GetMovieById(int id);
}