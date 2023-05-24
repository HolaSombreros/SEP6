namespace MovieManagement.Functions.Services;

public class GenreService : IGenreService
{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _repository;

    public GenreService(IGenreRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<GenreDto> GetGenreByIdAsync(int id)
    {
        var entity = await _repository.GetGenreByIdAsync(id);
        return _mapper.Map<GenreDto>(entity);
    }

    public async Task<IList<GenreDto?>> AddGenreAsync(IList<GenreDto?> genres)
    {
        var mappedGenres = new List<GenreDto>();
        foreach (var genre in genres)
        {
            var genreEntity = _mapper.Map<GenreEntity>(genre);
            var existingGenre = await GetGenreByIdAsync(genre!.GenreId);
            if (existingGenre is null)
            {
                var entity = await _repository.AddGenreAsync(genreEntity);
                var mapped = _mapper.Map<GenreDto>(entity);
                mappedGenres.Add(mapped);
            }
        }
        return mappedGenres;

    }
}