namespace MovieManagement.Functions.Ratings;

public class DeleteRating
{
    private readonly IRatingService _ratingService;
    
    public DeleteRating(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }
    
    [FunctionName("DeleteRating")]
    public async Task<IActionResult> DeleteMovieRating(
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get), Route = "/{ratingId}")][FromRoute] Guid ratingId ,
        ILogger log)
    {
        try
        {
            await _ratingService.DeleteRating(ratingId);

            return new OkResult();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}