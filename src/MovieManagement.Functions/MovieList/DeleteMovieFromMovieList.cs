namespace MovieManagement.Functions.MovieList; 

public class DeleteMovieFromMovieList {
    private readonly IMovieListService _movieListService;
    private readonly IValidator<MovieToMovieListDto> _validator;

    public DeleteMovieFromMovieList(IMovieListService movieListService, IValidator<MovieToMovieListDto> validator) {
        _movieListService = movieListService;
        _validator = validator;
    }
    [FunctionName("DeleteMovieFromMovieList")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Delete), Route = "DeleteMovieFromMovieList/{movieListId}/{movieId:int}")] HttpRequest req,  Guid movieListId, int movieId, ILogger log) {
        try
        {
            var request = new MovieToMovieListDto
            {
                MovieListId = movieListId,
                MovieId = movieId
            };

            var result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors);
            }

            await _movieListService.DeleteMovieFromMovieList(request);
            
            return new OkResult();
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
    
}