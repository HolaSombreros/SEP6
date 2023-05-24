namespace MovieManagement.Functions.MovieList; 

public class DeleteMovieList {
    private readonly IMovieListService _movieListService;

    public DeleteMovieList(IMovieListService movieListService) {
        _movieListService = movieListService;
    }
    [FunctionName("DeleteMovieList")]
    public  async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Delete), Route = "DeleteMovieList/{listId}")] HttpRequest req, [FromRoute]Guid listId, ILogger log) {
        try {
            await _movieListService.DeleteMovieListAsync(listId);

            return new OkResult();
        }
        catch (Exception e) {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }

        
    }
}