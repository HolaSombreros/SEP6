namespace MovieManagement.Database.Repositories;

public interface IMovieListMovieRepository
{
    Task<MovieListMovieEntity?> AddMovieToMovieList(MovieListMovieEntity movieListMovieEntity);
    Task<MovieListMovieEntity?> GetMovieFromMovieList(MovieListMovieEntity movieListMovieEntity);
}