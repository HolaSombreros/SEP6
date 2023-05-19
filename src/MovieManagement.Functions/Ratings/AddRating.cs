namespace MovieManagement.Functions.Ratings;

public class AddRating
{
    private readonly IRatingService _ratingService;
    private readonly IMovieService _movieService;
    private readonly IValidator<RatingDto> _validator;
    
    public AddRating(IRatingService ratingService, IValidator<RatingDto> validator, IMovieService movieService)
    {
        _ratingService = ratingService;
        _validator = validator;
        _movieService = movieService;
    }
    
    [FunctionName("AddRating")]
    public async Task<IActionResult> AddUserRating(
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
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }

            var updatedMovie = await _movieService.AddMovie(ratingDto.MovieDto);
            log.LogInformation("Add movie for movie id: " + updatedMovie.MovieId);

            var updatedRating = await _ratingService.PutRating(ratingDto);
            log.LogInformation("Add rating for rating id: " + updatedRating.RatingId + " and user id: " + updatedRating.UserId);


            updatedRating.MovieDto = updatedMovie;
            return new OkObjectResult(updatedRating);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}