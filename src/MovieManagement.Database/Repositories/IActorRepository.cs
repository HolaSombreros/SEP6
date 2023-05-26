namespace MovieManagement.Database.Repositories; 

public interface IActorRepository {
    Task<ActorEntity?> AddActorAsync(ActorEntity actorEntity);
    Task<ActorEntity?> GetActorAsync(int id);
    Task<List<string>> GetAgesByMovieAsync(int movieId);
    Task<List<int>> GetGenderForActorsInMainRoleByGenre(int genreId);

}