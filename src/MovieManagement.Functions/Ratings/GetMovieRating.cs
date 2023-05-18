namespace MovieManagement.Functions.Ratings;

public class GetMovieRating
{
    private readonly IRatingService _ratingService;
    
    public GetMovieRating(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }
    
    [FunctionName("GetMovieUserRating")]
    public async Task<IActionResult> GetMovieUserRating(
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get), Route = "GetMovieRating/{movieId:int}/{userId}")] HttpRequest req, int movieId, Guid userId,
        ILogger log)
    {
        try
        {
            var result = await _ratingService.GetMovieRatingByUser(movieId, userId);
            
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [FunctionName("GetMovieRatingsByIds")]
    public async Task<IActionResult> GetMovieRatingsByIds(
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get), Route = null)] HttpRequest req,
        ILogger log)
    {
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var ratingList = JsonConvert.DeserializeObject<IList<int>>(requestBody);
            var result = await _ratingService.GetMovieRatings(ratingList);
            
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}