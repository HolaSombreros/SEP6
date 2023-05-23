namespace MovieManagement.Functions.MovieList;

public class AddMovieToMovieList
{
    private readonly IMovieListService _movieListService;
    private readonly IValidator<MovieToMovieListDto> _validator;
    private readonly IMovieService _movieService;
    private readonly IValidator<MovieDto> _movieValidator;



    public AddMovieToMovieList(IMovieListService movieListService, IValidator<MovieToMovieListDto> validator, IValidator<MovieDto> movieValidator, IMovieService movieService)
    {
        _movieListService = movieListService;
        _validator = validator;
        _movieValidator = movieValidator;
        _movieService = movieService;
    }

    [FunctionName("AddMovieToMovieList")]
    public async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Put),
    Route = "AddMovieToMovieList/{movieListId}")] HttpRequest req, Guid movieListId, ILogger log)
    {
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            var movie = JsonConvert.DeserializeObject<MovieDto>(requestBody);
            var movieResult = await _movieValidator.ValidateAsync(movie);
            
            if (!movieResult.IsValid)
            {
                log.LogInformation("Body request not valid" + movieResult.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(movieResult.Errors);
            }

            await _movieService.AddMovieAsync(movie);
            log.LogInformation("Added movie for movie id: " + movie.MovieId);
            
            
            var request = new MovieToMovieListDto
            {
                MovieListId = movieListId,
                MovieId = movie.MovieId
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