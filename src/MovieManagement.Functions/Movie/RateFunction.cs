namespace MovieManagement.Functions.Movie;

public class RateFunction
{
    private readonly IRatingService _ratingService;
    private readonly IValidator<RatingDto> _validator;
    
    public RateFunction(IRatingService ratingService, IValidator<RatingDto> validator)
    {
        _ratingService = ratingService;
    }
    
    [FunctionName("AddRating")]
    public async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Put), Route = null)] HttpRequest req,
    ILogger log)
    {
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var ratingDto = JsonConvert.DeserializeObject<RatingDto>(requestBody);

            var result = await _validator.ValidateAsync(ratingDto);
            if (!result.IsValid)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            var updatedRating = await _ratingService.PutRating(ratingDto);
            
            return new OkObjectResult("Successfully inserted record");

        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}