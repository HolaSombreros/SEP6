namespace MovieManagement.Database.Repositories; 

public interface IMovieActorRepository {
    Task<MovieActorEntity?> AddMovieActorAsync(MovieActorEntity movieActorEntity);
    Task<MovieActorEntity?> GetAsync(int actorId, int movieId);
}