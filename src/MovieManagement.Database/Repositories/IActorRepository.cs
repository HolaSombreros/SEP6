namespace MovieManagement.Database.Repositories; 

public interface IActorRepository {
    Task<ActorEntity?> AddActorAsync(ActorEntity actorEntity);
    Task<ActorEntity?> UpdateActorAsync(ActorEntity actorEntity);
    Task<ActorEntity?> GetActorAsync(int id);
}