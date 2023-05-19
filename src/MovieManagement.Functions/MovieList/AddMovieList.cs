namespace MovieManagement.Functions.MovieList;

public class AddMovieList {
    private readonly IMovieListService _movieListService;
    private readonly IValidator<AddMovieListDto> _validator;

    public AddMovieList(IMovieListService movieListService, IValidator<AddMovieListDto> validator) {
        _movieListService = movieListService;
        _validator = validator;
    }

    [FunctionName("AddMovieList")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
        HttpRequest req, ILogger log) {
        try {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonConvert.DeserializeObject<AddMovieListDto>(requestBody);
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid) {
                return new BadRequestObjectResult(result.Errors);
            }

            var movieList = await _movieListService.AddMovieListAsync(dto);

            return new OkObjectResult(movieList);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
    }
}