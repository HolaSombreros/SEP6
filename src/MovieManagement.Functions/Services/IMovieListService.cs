namespace MovieManagement.Functions.Services; 

public interface IMovieListService {
    Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto);
    Task<MovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto);
    Task<List<MovieListDto>> GetMovieLists(Guid userId);
    Task DeleteMovieList(Guid movieListId);
    Task DeleteMovieFromMovieList(MovieToMovieListDto movieToMovieListDto);
}