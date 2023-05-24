namespace MovieManagement.Functions.Services;

public interface IMovieService
{
    Task<MovieDto> AddMovieAsync(MovieDto movieDto);
    Task<MovieDto> GetMovieByIdAsync(int id);
}