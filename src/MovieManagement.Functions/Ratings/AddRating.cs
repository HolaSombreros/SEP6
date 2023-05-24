namespace MovieManagement.Functions.Ratings;

public class AddRating
{
    private readonly IRatingService _ratingService;
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;
    private readonly IMovieGenreService _movieGenreService;
    private readonly IValidator<RatingDto> _validator;
    
    public AddRating(IRatingService ratingService, IValidator<RatingDto> validator, IMovieService movieService, IGenreService genreService, IMovieGenreService movieGenreService)
    {
        _ratingService = ratingService;
        _validator = validator;
        _movieService = movieService;
        _genreService = genreService;
        _movieGenreService = movieGenreService;
    }
    
    [FunctionName("AddRating")]
    public async Task<IActionResult> AddUserRating(
    [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Put), Route = null)] HttpRequest req,
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

            await _genreService.AddGenreAsync(ratingDto.MovieDto.Genres!);
            await _movieGenreService.AddMovieGenreAsync(ratingDto.MovieDto.Genres!, ratingDto.MovieDto.MovieId);
            
            var updatedRating = await _ratingService.PutRating(ratingDto);
            log.LogInformation("Added rating for rating id: " + updatedRating.RatingId + " and user id: " + updatedRating.UserId);

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