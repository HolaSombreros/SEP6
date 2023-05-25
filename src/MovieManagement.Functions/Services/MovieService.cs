namespace MovieManagement.Functions.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<MovieDto> AddMovieAsync(MovieDto movieDto)
    {
        var movieEntity = _mapper.Map<MovieEntity>(movieDto);
        var existingMovie = await GetMovieByIdAsync(movieDto.MovieId);
        if (existingMovie is not null)
        {
            return existingMovie;
        }
        var entity = await _repository.AddMovieAsync(movieEntity);
        return _mapper.Map<MovieDto>(entity);
    }

    public async Task<MovieDto> GetMovieByIdAsync(int id)
    {
        var entity = await _repository.GetMovieByIdAsync(id);
        return _mapper.Map<MovieDto>(entity);
    }

    public async Task<List<MovieDto>> AddMoviesAsync(List<AddMovieActorDto> movies) {
        var movieList = new List<MovieDto>();
        foreach (var movie in movies) {
            var dto = new MovieDto() {
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                MovieId = movie.MovieId,
                ReleaseDate = movie.ReleaseDate
            };
            movieList.Add(dto);
            await AddMovieAsync(dto);
        }

        return movieList;
    }
}