namespace MovieManagement.Functions.Services; 

public interface IMovieListService {
    Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto);
    Task<AddMovieToMovieListDto> AddMovieToMovieListAsync(AddMovieToMovieListDto addMovieToMovieListDto);
    Task<MovieListMovieEntity?> GetMovieFromMovieList(MovieListMovieEntity movieListMovieEntity);
    Task<List<MovieListDto>> GetMovieLists(Guid userId);
    Task DeleteMovieList(Guid movieListId);
}