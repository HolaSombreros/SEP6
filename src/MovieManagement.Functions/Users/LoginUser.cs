namespace MovieManagement.Functions.Users; 

public class LoginUser {
    private readonly IUserService _userService;
    private readonly IValidator<LoginUserDto> _validator;

    public LoginUser(IUserService userService, IValidator<LoginUserDto> validator) {
        _userService = userService;
        _validator = validator;
    }

    [FunctionName("LoginUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        try {
            
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var loginUserDto = JsonConvert.DeserializeObject<LoginUserDto>(requestBody);
            var result = await _validator.ValidateAsync(loginUserDto);
            if (!result.IsValid)
            {
                return new BadRequestObjectResult(result.Errors);
            }
            var user = await _userService.GetUser(loginUserDto);

            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
       
    }
}