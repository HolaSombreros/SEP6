namespace MovieManagement.Functions.MovieList; 

public class GetMovieLists {
    private readonly IMovieListService _movieListService;

    public GetMovieLists(IMovieListService movieListService) {
        _movieListService = movieListService;
    }

    [FunctionName("GetMovieLists")]
    public  async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.System, nameof(HttpMethods.Get), Route = "GetMovieLists/{userId}")] HttpRequest req, [FromRoute]Guid userId, ILogger log) {
        log.LogInformation("C# HTTP trigger function processed a request");

        try {
            var movieList = await _movieListService.GetMovieLists(userId);

            return new OkObjectResult(movieList);
        }
        catch (Exception e) {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}