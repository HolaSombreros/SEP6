namespace MovieManagement.Functions.Users;

public class RegisterUser
{
    private readonly IUserService _userService;
    private readonly IValidator<RegisterUserDto> _validator;
    private readonly IMovieListService _movieListService;

    public RegisterUser(IUserService userService, IValidator<RegisterUserDto> validator, IMovieListService movieListService) {
        _userService = userService;
        _validator = validator;
        _movieListService = movieListService;
    }

    [FunctionName("RegisterUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        try 
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var registerUserDto = JsonConvert.DeserializeObject<RegisterUserDto>(requestBody);
            var result = await _validator.ValidateAsync(registerUserDto!);
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }
            var user = await _userService.RegisterUserAsync(registerUserDto!);
            await _movieListService.AddMovieListAsync(new AddMovieListDto() {
                UserId = user.UserId, Title = "Favourites"
            });
            await _movieListService.AddMovieListAsync(new AddMovieListDto() {
                UserId = user.UserId, Title = "To Watch"
            });
            
            return new OkObjectResult(user);
        }
        catch (Exception e) 
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}