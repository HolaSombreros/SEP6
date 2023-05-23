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

    public async Task<MovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto)
    {
        var movieListMovieEntity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        var existingMovieInList = await _listMovieRepository.GetMovieFromMovieListAsync(movieListMovieEntity);
        
        if (existingMovieInList != null)
        {
            throw new Exception("The movie already exists in the list");
        }
        
        await _listMovieRepository.AddMovieToMovieListAsync(movieListMovieEntity);
       
        var listEntity = await _repository.GetAsync(movieToMovieListDto.MovieListId);
        var movies = await _listMovieRepository.GetMoviesByListAsync(movieToMovieListDto.MovieListId);
        
        var movieList = _mapper.Map<MovieListDto>(listEntity);
        movieList.Movies = _mapper.Map<List<MovieDto>>(movies);
        
        return movieList;
    }

    public async Task<List<MovieListDto>> GetMovieListsAsync(Guid userId) {
        if ((await _userRepository.GetAsync(userId)) is null) {
            throw new Exception("User doesn't exist");
        }
        var list = await _repository.GetMovieListsByUserAsync(userId);
        var mappedList = _mapper.Map<List<MovieListDto>>(list);
        foreach (var movieList in mappedList) {
            var movies = await _listMovieRepository.GetMoviesByListAsync(movieList.MovieListId);
            movieList.Movies = _mapper.Map<List<MovieDto>>(movies);
        }
        return mappedList;
    }

    public async Task DeleteMovieListAsync(Guid movieListId) {
        var movieList = await _repository.GetAsync(movieListId);
        if (movieList is null) {
            throw new Exception("Movie List doesn't exist");
        }

        await _repository.DeleteAsync(movieListId);
    }

    public async Task DeleteMovieFromMovieListAsync(MovieToMovieListDto movieToMovieListDto) {
        var entity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        if (await _listMovieRepository.GetMovieFromMovieListAsync(entity) is null) {
            throw new Exception("Movie not in list");
        }

        await _listMovieRepository.DeleteMovieFromMovieListAsync(entity);
    }
}