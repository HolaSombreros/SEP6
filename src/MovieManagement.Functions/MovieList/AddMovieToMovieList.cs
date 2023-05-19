namespace MovieManagement.Functions.MovieList;

public class AddMovieToMovieList
{
    private readonly IMovieListService _movieListService;
    private readonly IValidator<AddMovieToMovieListDto> _validator;

    public AddMovieToMovieList(IMovieListService movieListService, IValidator<AddMovieToMovieListDto> validator)
    {
        _movieListService = movieListService;
        _validator = validator;
    }

    [FunctionName("AddMovieToMovieList")]
    public async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Put),
    Route = "AddMovieToMovieList/{movieListId}/{movieId:int}")] HttpRequest req, Guid movieListId, int movieId, ILogger log)
    {
        try
        {
            var request = new AddMovieToMovieListDto
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

            var list = await _movieListService.AddMovieToMovieListAsync(request);
            
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}