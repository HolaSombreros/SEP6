namespace MovieManagement.Database.Repositories;

public interface IMovieListMovieRepository
{
    Task<MovieListMovieEntity?> AddMovieToMovieListAsync(MovieListMovieEntity movieListMovieEntity);
    Task<MovieListMovieEntity?> GetMovieFromMovieListAsync(MovieListMovieEntity movieListMovieEntity);
    Task DeleteMovieFromMovieListAsync(MovieListMovieEntity movieListMovieEntity);
}