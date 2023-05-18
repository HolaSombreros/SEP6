namespace MovieManagement.Functions.Services;

public interface IMovieService
{
    Task<MovieDto> AddMovie(MovieDto movieDto);
    Task<MovieDto> GetMovieById(int id);
}