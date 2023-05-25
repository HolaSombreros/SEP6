namespace MovieManagement.Services; 

public class ActorService : IActorService {
    private readonly IAzureService _service;
    private readonly AzureFunctionsConfig _settings;

    public ActorService(IAzureService service, IOptions<AzureFunctionsConfig> settings) {
        _service = service;
        _settings = settings.Value;
    }

    public async Task AddMovieActor(PersonViewModel viewModel) {
        var actor = new ActorDto(viewModel);
        await _service.PostAsync<string>(_settings.AddMovieActor, actor);
    }
    
}