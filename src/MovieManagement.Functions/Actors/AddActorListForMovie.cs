namespace MovieManagement.Functions.Actors; 

public class AddActorListForMovie {

    private readonly IMovieActorService _movieActorService;
    private readonly IActorService _actorService;
    private readonly IMovieService _movieService;
    private IValidator<ActorDto> _actorValidator;
    private IValidator<AddMovieActorDto> _movieActorValidator;

    public AddActorListForMovie(IMovieActorService movieActorService, IActorService actorService, IMovieService movieService, IValidator<ActorDto> actorValidator, IValidator<AddMovieActorDto> movieActorValidator) {
        _movieActorService = movieActorService;
        _actorService = actorService;
        _movieService = movieService;
        _actorValidator = actorValidator;
        _movieActorValidator = movieActorValidator;
    }

    [FunctionName("AddActorListForMovie")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log) {
        try {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonConvert.DeserializeObject<ActorDto>(requestBody);
            var result = await _actorValidator.ValidateAsync(dto!);
            if (!result.IsValid) {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
            }

            var actorList = await _actorService.AddActorAsync(dto!);
            foreach (var movie in dto!.Movies) {
                var movieResult = await _movieActorValidator.ValidateAsync(movie);
                if (!movieResult.IsValid) {
                    log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                }
            }
            var movieList = await _movieService.AddMoviesAsync(dto!.Movies);
            var list = await _movieActorService.AddMovieActorsAsync(dto.Movies, dto.ActorId);
            
            return new OkObjectResult(actorList);
        }
        catch (Exception e) {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}