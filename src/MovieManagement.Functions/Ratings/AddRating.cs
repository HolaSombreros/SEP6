namespace MovieManagement.Functions.Ratings;

public class AddRating
{
    private readonly IRatingService _ratingService;
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;
    private readonly IValidator<RatingDto> _validator;
    
    public AddRating(IRatingService ratingService, IValidator<RatingDto> validator, IMovieService movieService, IGenreService genreService)
    {
        _ratingService = ratingService;
        _validator = validator;
        _movieService = movieService;
        _genreService = genreService;
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

            var result = await _validator.ValidateAsync(ratingDto!);
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }

            var updatedMovie = await _movieService.AddMovieAsync(ratingDto!.MovieDto);
            log.LogInformation("Added movie for movie id: " + updatedMovie.MovieId);

            var updatedGenres = await _genreService.AddGenreAsync(ratingDto.MovieDto.Genres!);

            var updatedRating = await _ratingService.PutRating(ratingDto);
            log.LogInformation("Added rating for rating id: " + updatedRating.RatingId + " and user id: " + updatedRating.UserId);

            updatedRating.MovieDto = updatedMovie;
            updatedRating.MovieDto.Genres = updatedGenres;

            return new OkObjectResult(updatedRating);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}