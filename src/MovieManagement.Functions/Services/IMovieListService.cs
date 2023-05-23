namespace MovieManagement.Functions.Services; 

public interface IMovieListService {
    Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto);
    Task<MovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto);
    Task<List<MovieListDto>> GetMovieListsAsync(Guid userId);
    Task DeleteMovieListAsync(Guid movieListId);
    Task DeleteMovieFromMovieListAsync(MovieToMovieListDto movieToMovieListDto);
}