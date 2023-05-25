namespace MovieManagement.Functions.Statistics; 

public class DistributionOfAgeInAMovie {
    
    private readonly IStatisticsService _statisticsService;

    public DistributionOfAgeInAMovie(IStatisticsService statisticsService) {
        _statisticsService = statisticsService;
    }


    [FunctionName("DistributionOfAgeInAMovie")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "DistributionOfAgeInAMovie/{movieId:int}")] HttpRequest req, int movieId, ILogger log) {
        try
        {
            var result = await _statisticsService.GetAgeDistributionAsync(movieId);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}