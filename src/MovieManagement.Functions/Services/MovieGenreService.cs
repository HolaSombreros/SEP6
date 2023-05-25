namespace MovieManagement.Functions.Services;

public class MovieGenreService : IMovieGenreService
{
    private readonly IMapper _mapper;
    private readonly IMovieGenreRepository _repository;

    public MovieGenreService(IMapper mapper, IMovieGenreRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<MovieGenreDto> GetMovieGenreAsync(int movieId, int genreId)
    {
        var entity = await _repository.GetMovieGenreAsync(movieId, genreId);    
        return _mapper.Map<MovieGenreDto>(entity);
    }

    public async Task<IList<MovieGenreDto>> AddMovieGenreAsync(IList<GenreDto> genres, int movieId)
    {
        var mappedGenres = new List<MovieGenreDto>();
        foreach (var genre in genres)
        {
            var genreEntity = _mapper.Map<MovieGenreEntity>(genre);
            genreEntity.MovieId = movieId;
            var existingGenre = await GetMovieGenreAsync(movieId, genre.GenreId);
            if (existingGenre is null)
            {
                var entity = await _repository.AddMovieGenreAsync(genreEntity);
                var mapped = _mapper.Map<MovieGenreDto>(entity);
                mappedGenres.Add(mapped);
            }
        }
        return mappedGenres;
    }
}