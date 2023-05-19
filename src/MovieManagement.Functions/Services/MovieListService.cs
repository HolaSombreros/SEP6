namespace MovieManagement.Functions.Services; 

public class MovieListService : IMovieListService {
    private readonly IMovieListRepository _repository;
    private readonly IMapper _mapper;


    public MovieListService(IMovieListRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MovieListDto> AddMovieListAsync(AddMovieListDto addMovieListDto) {

        var movieListEntity = _mapper.Map<MovieListEntity>(addMovieListDto);
        movieListEntity.MovieListId = new Guid();

        await _repository.AddAsync(movieListEntity);

        var movieList = _mapper.Map<MovieListDto>(movieListEntity);
        return movieList;

    }
}