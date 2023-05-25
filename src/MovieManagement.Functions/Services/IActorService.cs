namespace MovieManagement.Functions.Services; 

public interface IActorService {
    Task<ActorDto> AddActorAsync(ActorDto actorDto);
    Task<List<ActorDto>> AddActorsAsync(List<ActorDto> actorDtos);
}