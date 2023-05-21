namespace MovieManagement.Functions.Services; 

public interface IMovieListService {
    Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto);
    Task<MovieToMovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto);
    Task<MovieListMovieEntity?> GetMovieFromMovieList(MovieListMovieEntity movieListMovieEntity);
    Task<List<MovieListDto>> GetMovieLists(Guid userId);
    Task DeleteMovieList(Guid movieListId);
    Task DeleteMovieFromMovieList(MovieToMovieListDto movieToMovieListDto);
}