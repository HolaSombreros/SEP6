namespace MovieManagement.Functions.Statistics;

public class DistributionOfRatingByGenre
{
    private readonly IStatisticsService _statisticsService;

    public DistributionOfRatingByGenre(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [FunctionName("DistributionOfRatingByGenre")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "DistributionOfRatingByGenre/{genreId:int}")] HttpRequest req, int genreId, ILogger log)
    {
        try
        {
            var result = await _statisticsService.Get(genreId);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}