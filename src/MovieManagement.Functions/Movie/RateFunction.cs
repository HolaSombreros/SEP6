namespace MovieManagement.Functions.Movie;

public class RateFunction
{
    private readonly IRatingService _ratingService;
    private readonly IMovieService _movieService;
    private readonly IValidator<RatingDto> _validator;
    
    public RateFunction(IRatingService ratingService, IValidator<RatingDto> validator, IMovieService movieService)
    {
        _ratingService = ratingService;
        _validator = validator;
        _movieService = movieService;
    }
    
    [FunctionName("AddRating")]
    public async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Put), Route = null)] HttpRequest req,
    ILogger log)
    {
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var ratingDto = JsonConvert.DeserializeObject<RatingDto>(requestBody);

            var result = await _validator.ValidateAsync(ratingDto);
            if (!result.IsValid)
            {
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }

            var updatedMovie = await _movieService.AddMovie(ratingDto.MovieDto);
            var updatedRating = await _ratingService.PutRating(ratingDto);

            updatedRating.MovieDto = updatedMovie;
            
            return new OkObjectResult(updatedRating);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}