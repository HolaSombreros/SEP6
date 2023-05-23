namespace MovieManagement.Functions.Services; 

public class MovieListService : IMovieListService
{
    private readonly IMovieListRepository _repository;
    private readonly IMovieListMovieRepository _listMovieRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public MovieListService(IMovieListRepository repository, IMapper mapper, IMovieListMovieRepository listMovieRepository, IUserRepository userRepository) {
        _repository = repository;
        _mapper = mapper;
        _listMovieRepository = listMovieRepository;
        _userRepository = userRepository;
    }

    public async Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto) {

        var movieListEntity = _mapper.Map<MovieListEntity>(addMovieListDto);
        movieListEntity.MovieListId = new Guid();

        await _repository.AddAsync(movieListEntity);

        var movieList = _mapper.Map<MovieListDto>(movieListEntity);
        return movieList;
    }

    public async Task<MovieToMovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto)
    {
        var movieListMovieEntity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        var existingMovieInList = await GetMovieFromMovieList(movieListMovieEntity);
        if (existingMovieInList != null)
        {
            throw new Exception("The movie already exists in the list");
        }
        var result =await _listMovieRepository.AddMovieToMovieList(movieListMovieEntity);
        
        var movieList = _mapper.Map<MovieToMovieListDto>(movieListMovieEntity);
        return movieList;
    }

    public async Task<MovieListMovieEntity> GetMovieFromMovieList(MovieListMovieEntity movieListMovieEntity)
    {
        return await _listMovieRepository.GetMovieFromMovieList(movieListMovieEntity);
    }

    public async Task<List<MovieListDto>> GetMovieLists(Guid userId) {
        if ((await _userRepository.GetAsync(userId)) is null) {
            throw new Exception("User doesn't exist");
        }
        var list = await _repository.GetMovieListsByUser(userId);
        var mappedList = _mapper.Map<List<MovieListDto>>(list);
        foreach (var movieList in mappedList) {
            var movies = await _repository.GetMoviesByList(movieList.MovieListId);
            movieList.Movies = _mapper.Map<List<MovieDto>>(movies);
        }
        return mappedList;
    }

    public async Task DeleteMovieList(Guid movieListId) {
        var movieList = await _repository.GetAsync(movieListId);
        if (movieList is null) {
            throw new Exception("Movie List doesn't exist");
        }

        if (movieList.Title.Equals("To Watch") || movieList.Title.Equals("Favourites")) {
            throw new Exception("Cannot delete movie list");
        }

        await _repository.DeleteAsync(movieListId);
    }

    public async Task DeleteMovieFromMovieList(MovieToMovieListDto movieToMovieListDto) {
        var entity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        if (await _listMovieRepository.GetMovieFromMovieList(entity) is null) {
            throw new Exception("Movie not in list");
        }

        await _listMovieRepository.DeleteMovieFromMovieList(entity);
    }
}