namespace MovieManagement.Functions.Services; 

public interface IMovieListMovieService {
    Task<MovieToMovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto);
    Task DeleteMovieFromMovieList(MovieToMovieListDto movieToMovieListDto);

}