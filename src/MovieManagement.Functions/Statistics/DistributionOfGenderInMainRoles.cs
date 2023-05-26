namespace MovieManagement.Functions.Statistics; 

public class DistributionOfGenderInMainRoles {
    private readonly IStatisticsService _statisticsService;

    public DistributionOfGenderInMainRoles(IStatisticsService statisticsService) {
        _statisticsService = statisticsService;
    }

    [FunctionName("DistributionOfGenderInMainRoles")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous,nameof(HttpMethods.Get) , Route = null)] HttpRequest req, ILogger log) {
        try {
            string genre = req.Query["genreId"];
            int genreId = genre == null? 0 : int.Parse(genre);
            var result = await _statisticsService.GetGenderDistributionInMainRoles(genreId);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}