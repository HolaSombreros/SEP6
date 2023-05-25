namespace MovieManagement.Functions.Services; 

public interface IMovieActorService {
    Task<List<MovieActorDto>> AddMovieActorsAsync(List<AddMovieActorDto> movieActorDtos, int actorId);
}
