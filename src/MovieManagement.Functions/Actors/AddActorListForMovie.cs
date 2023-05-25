namespace MovieManagement.Functions.Actors; 

public class AddActorListForMovie {

    private readonly IMovieActorService _movieActorService;
    private readonly IActorService _actorService;
    private readonly IMovieService _movieService;


    public AddActorListForMovie(IMovieActorService movieActorService, IActorService actorService, IMovieService movieService) {
        _movieActorService = movieActorService;
        _actorService = actorService;
        _movieService = movieService;
    }

    [FunctionName("AddActorListForMovie")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log) {
        try {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonConvert.DeserializeObject<ActorDto>(requestBody);
            var actorList = await _actorService.AddActorAsync(dto);
            var movieList = await _movieService.AddMoviesAsync(dto.Movies);
            var list = await _movieActorService.AddMovieActorsAsync(dto.Movies, dto.ActorId);
            
            return new OkObjectResult("Actor credits added successfully");
        }
        catch (Exception e) {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}