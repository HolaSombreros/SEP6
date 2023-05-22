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
    
    public async Task<MovieDto> AddMovie(MovieDto movieDto)
    {
        var movieEntity = _mapper.Map<MovieEntity>(movieDto);
        var existingMovie = await GetMovieById(movieDto.MovieId);
        if (existingMovie is not null)
        {
            return existingMovie;
        }
        var entity = await _repository.AddMovieAsync(movieEntity);
        return _mapper.Map<MovieDto>(entity);
    }

    public async Task<MovieDto> GetMovieById(int id)
    {
        var entity = await _repository.GetMovieByIdAsync(id);
        return _mapper.Map<MovieDto>(entity);
    }
}