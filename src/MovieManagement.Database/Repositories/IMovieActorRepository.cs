namespace MovieManagement.Database.Repositories; 

public interface IMovieActorRepository {
    Task<MovieActorEntity?> AddMovieActorAsync(MovieActorEntity movieActorEntity);
    Task<List<MovieEntity?>> GetMoviesForActor(int actorId);
    Task<List<MovieActorEntity?>> GetMoviesRolesForActor(int actorId);
    Task<MovieActorEntity?> GetAsync(int actorId, int movieId);
}