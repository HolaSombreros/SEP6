namespace MovieManagement.Functions.Services; 

public interface IMovieListService {
    Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto);
    Task<List<MovieListDto>> GetMovieListsAsync(Guid userId);
    Task DeleteMovieListAsync(Guid movieListId);
}