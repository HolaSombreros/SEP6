namespace MovieManagement.Functions.Services; 

public class MovieListService : IMovieListService
{
    private readonly IMovieListRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public MovieListService(IMovieListRepository repository, IMapper mapper, IUserRepository userRepository) {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto) {

        var movieListEntity = _mapper.Map<MovieListEntity>(addMovieListDto);
        movieListEntity.MovieListId = new Guid();
        if ((await _userRepository.GetAsync(addMovieListDto.UserId)) is null) {
            throw new Exception("User doesn't exist");
        }
        await _repository.AddAsync(movieListEntity);

        var movieList = _mapper.Map<MovieListDto>(movieListEntity);
        return movieList;
    }

   

    public async Task<List<MovieListDto>> GetMovieListsAsync(Guid userId) {
        if ((await _userRepository.GetAsync(userId)) is null) {
            throw new Exception("User doesn't exist");
        }
        var list = await _repository.GetMovieListsByUserAsync(userId);
        var mappedList = _mapper.Map<List<MovieListDto>>(list);
        foreach (var movieList in mappedList) {
            var movies = await _repository.GetMoviesByListAsync(movieList.MovieListId);
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

    
}