namespace MovieManagement.Functions.Movie;

public static class RateFunction
{
    [FunctionName("AddRating")]
    public static async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Post), Route = null)] HttpRequest req,
    [Sql(commandText: "dbo.Rating", connectionStringSetting: "DbConnectionString")] IAsyncCollector<RatingEntity> ratingTable,
    [Sql(commandText: "dbo.Movie_Rating", connectionStringSetting: "DbConnectionString")] IAsyncCollector<MovieRatingEntity> movieRatingTable,
    [Sql(commandText: "dbo.Movie", connectionStringSetting: "DbConnectionString")] IAsyncCollector<MovieEntity> movieTable,
    ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var movieRatingDto = JsonConvert.DeserializeObject<MovieRatingDto>(requestBody);
        
        //TODO: add validation
        var ratingId = Guid.NewGuid();
        
        await movieTable.AddAsync(new MovieEntity()
        {
            movie_id = movieRatingDto.MovieId
        });
        
        await ratingTable.AddAsync(new RatingEntity()
        {
            rating_id = ratingId,
            user_id = movieRatingDto.UserId,
            rating = movieRatingDto.Rating,
            review = movieRatingDto.Review,
            is_deleted = movieRatingDto.IsDeleted
        });
        await movieRatingTable.AddAsync(new MovieRatingEntity()
        {
            movie_id = movieRatingDto.MovieId,
            rating_id = ratingId 
        });
        
        return new OkObjectResult("Successfully inserted record");
    }
}