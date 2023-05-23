namespace MovieManagement.Functions.Ratings;

public class GetMovieRating
{
    private readonly IRatingService _ratingService;
    private readonly IValidator<GetRatingDto> _validator;

    public GetMovieRating(IRatingService ratingService, IValidator<GetRatingDto> validator)
    {
        _ratingService = ratingService;
        _validator = validator;
    }
    
    [FunctionName("GetMovieRating")]
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
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get), Route = null)] HttpRequest req,
         ILogger log)
    {
        try
        {
            var page = int.Parse(req.Query["page"]);
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var getRatingDto = JsonConvert.DeserializeObject<GetRatingDto>(requestBody);
            var result = await _validator.ValidateAsync(getRatingDto);
            
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }
            var ratingResultDto = await _ratingService.GetMovieRatings(getRatingDto, page);
            
            return new OkObjectResult(ratingResultDto);
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