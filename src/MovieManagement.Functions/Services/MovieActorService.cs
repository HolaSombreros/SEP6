namespace MovieManagement.Functions.Services; 

public class MovieActorService : IMovieActorService {
    private readonly IMovieActorRepository _movieActorRepository;
    private readonly IMapper _mapper;

    public MovieActorService(IMapper mapper, IMovieActorRepository movieActorRepository) {
        _mapper = mapper;
        _movieActorRepository = movieActorRepository;
    }

    public async Task<List<MovieActorDto>> AddMovieActorsAsync(List<AddMovieActorDto> movieActorDtos, int actorId) {
        var dtoList = new List<MovieActorDto>();
        if(movieActorDtos is not null) {
            foreach (var movie in movieActorDtos) {
                dtoList.Add(new MovieActorDto() {
                    ActorId = actorId,
                    MovieOrder = movie.MovieOrder,
                    MovieId = movie.MovieId
                });
            }

            var list = _mapper.Map<List<MovieActorEntity>>(dtoList);

            foreach (var ma in list) {
                if (await _movieActorRepository.GetAsync(ma.ActorId, ma.MovieId) is null) {
                    await _movieActorRepository.AddMovieActorAsync(ma);
                }
            }

            return _mapper.Map<List<MovieActorDto>>(list);
        }

        return null;
    }
}