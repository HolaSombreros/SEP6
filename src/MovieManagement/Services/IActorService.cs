namespace MovieManagement.Services; 

public interface IActorService {
    Task AddMovieActor(PersonViewModel viewModel);
}