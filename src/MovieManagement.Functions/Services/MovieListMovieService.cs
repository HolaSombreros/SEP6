namespace MovieManagement.Functions.Services; 

public class MovieListMovieService : IMovieListMovieService{
    
    private readonly IMapper _mapper;
    private readonly IMovieListMovieRepository _listMovieRepository;

    public MovieListMovieService(IMapper mapper, IMovieListMovieRepository listMovieRepository) {
        _mapper = mapper;
        _listMovieRepository = listMovieRepository;
    }


    public async Task<MovieToMovieListDto> AddMovieToMovieListAsync(MovieToMovieListDto movieToMovieListDto)
    {
        var movieListMovieEntity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        var existingMovieInList = await _listMovieRepository.GetMovieFromMovieListAsync(movieListMovieEntity);
        if (existingMovieInList != null)
        {
            throw new Exception("The movie already exists in the list");
        }
        var result =await _listMovieRepository.AddMovieToMovieListAsync(movieListMovieEntity);
        
        var movieList = _mapper.Map<MovieToMovieListDto>(movieListMovieEntity);
        return movieList;
    }

    
    public async Task DeleteMovieFromMovieList(MovieToMovieListDto movieToMovieListDto) {
        var entity = _mapper.Map<MovieListMovieEntity>(movieToMovieListDto);
        if (await _listMovieRepository.GetMovieFromMovieListAsync(entity) is null) {
            throw new Exception("Movie not in list");
        }

        await _listMovieRepository.DeleteMovieFromMovieListAsync(entity);
    }
}