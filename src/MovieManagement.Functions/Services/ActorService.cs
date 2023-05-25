namespace MovieManagement.Functions.Services; 

public class ActorService : IActorService {
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;


    public ActorService(IActorRepository actorRepository, IMapper mapper) {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }

    public async Task<ActorDto> AddActorAsync(ActorDto actorDto) {
        var actorEntity = _mapper.Map<ActorEntity>(actorDto);
        var actor = await _actorRepository.GetActorAsync(actorDto.ActorId);
        if (actor is null) {
            var addedActor = await _actorRepository.AddActorAsync(actorEntity);
            return _mapper.Map<ActorDto>(addedActor);
        }
        return actorDto;
    }

    public async Task<List<ActorDto>> AddActorsAsync(List<ActorDto> actorDtos) {
        foreach (var actor in actorDtos) {
            await AddActorAsync(actor);
        }

        return actorDtos;
    }
}