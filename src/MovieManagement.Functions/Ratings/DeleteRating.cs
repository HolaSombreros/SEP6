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
        [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Delete), Route = "DeleteRating/{ratingId}")] HttpRequest request, [FromRoute] Guid ratingId,
        ILogger log)
    {
        try
        {
            await _ratingService.DeleteRating(ratingId);
            log.LogInformation("Rating with the id {ratingId} has been deleted", ratingId);

            return new OkResult();
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}