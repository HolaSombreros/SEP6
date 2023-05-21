namespace MovieManagement.Functions.Services; 

public class MovieListService : IMovieListService
{
    private readonly IMovieListRepository _repository;
    private readonly IMovieListMovieRepository _listMovieRepository;
    private readonly IMapper _mapper;

    public MovieListService(IMovieListRepository repository, IMapper mapper, IMovieListMovieRepository listMovieRepository) {
        _repository = repository;
        _mapper = mapper;
        _listMovieRepository = listMovieRepository;
    }

    public async Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto) {

        var movieListEntity = _mapper.Map<MovieListEntity>(addMovieListDto);
        movieListEntity.MovieListId = new Guid();

        await _repository.AddAsync(movieListEntity);

        var movieList = _mapper.Map<MovieListDto>(movieListEntity);
        return movieList;
    }

    public async Task<AddMovieToMovieListDto> AddMovieToMovieListAsync(AddMovieToMovieListDto addMovieToMovieListDto)
    {
        var movieListMovieEntity = _mapper.Map<MovieListMovieEntity>(addMovieToMovieListDto);
        var existingMovieInList = await GetMovieFromMovieList(movieListMovieEntity);
        if (existingMovieInList != null)
        {
            throw new Exception("The movie already exists in the list");
        }
        var result =await _listMovieRepository.AddMovieToMovieList(movieListMovieEntity);
        
        var movieList = _mapper.Map<AddMovieToMovieListDto>(movieListMovieEntity);
        return movieList;
    }

    public async Task<MovieListMovieEntity> GetMovieFromMovieList(MovieListMovieEntity movieListMovieEntity)
    {
        return await _listMovieRepository.GetMovieFromMovieList(movieListMovieEntity);
    }

    public async Task<List<MovieListDto>> GetMovieLists(Guid userId) {
        var list = await _repository.GetMovieListsByUser(userId);
        var mappedList = _mapper.Map<List<MovieListDto>>(list);
        foreach (var movieList in mappedList) {
            var movies = await _repository.GetMoviesByList(movieList.MovieListId);
            movieList.Movies = _mapper.Map<List<MovieDto>>(movies);
        }
        return mappedList;
    }
}