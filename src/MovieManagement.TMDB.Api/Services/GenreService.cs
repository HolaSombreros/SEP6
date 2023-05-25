namespace MovieManagement.TMDB.Api.Services;

public class GenreService : IGenreService
{
    private readonly IService _service;
    private readonly IMapper _mapper;
    private readonly ApiConfig _settings;

    public GenreService(IService service, IMapper mapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _mapper = mapper;
        _settings = settings.Value;
    }

    public async Task<GenreList>? GetAllGenresAsync()
    {
        try
        {
            var genreDto = await _service.GetAsync<GenreListDto>(_settings.GenrePath + _settings.MoviePath + "list" + _settings.QueryBuilder);
            return _mapper.Map<GenreListDto, GenreList>(genreDto);
        }
        catch
        {
            return new GenreList();
        }
    }
}