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
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [FunctionName("GetMovieRatings")]
    public async Task<IActionResult> GetMovieRatings(
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get), Route = "GetMovieRatings/{movieId:int}/{userId}")] HttpRequest req, int movieId, Guid userId,
         ILogger log)
    {
        // TODO - Put movieId + userId in body of request - especially considering the userId can be null. Applies to method above too which I'm also not sure we will even use...?

        // Why take "pageSize" as a query parameter - shouldn't the function decide how many to return?
        // Also, we don't actually *need* pagination on this one. That could be project future for example. Not sure it makes sense to implement it with pagination on the UI side at least,
        // so maybe allow no pagination too, if f.x. the page query parameter is not present.

        try
        {
            var page = int.Parse(req.Query["page"]);
            var pageSize = int.Parse(req.Query["pageSize"]);
            var result = await _ratingService.GetMovieRatings(movieId, userId, page, pageSize);
            
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
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
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}