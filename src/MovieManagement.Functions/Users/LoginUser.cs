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
        [HttpTrigger(AuthorizationLevel.Anonymous,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        try {
            
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var loginUserDto = JsonConvert.DeserializeObject<LoginUserDto>(requestBody);
            var result = await _validator.ValidateAsync(loginUserDto);
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors[0].ErrorMessage);
            }
            var user = await _userService.GetUserAsync(loginUserDto);

            return new OkObjectResult(user);
        }
        catch (Exception e)
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
       
    }
}