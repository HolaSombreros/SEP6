namespace MovieManagement.Functions.Users;

public class RegisterUser
{
    private readonly IUserService _userService;
    private readonly IValidator<RegisterUserDto> _validator;

    public RegisterUser(IUserService userService, IValidator<RegisterUserDto> validator) {
        _userService = userService;
        _validator = validator;
    }

    [FunctionName("RegisterUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        try 
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var registerUserDto = JsonConvert.DeserializeObject<RegisterUserDto>(requestBody);
            var result = await _validator.ValidateAsync(registerUserDto);
            if (!result.IsValid)
            {
                return new BadRequestObjectResult(result.Errors);
            }
            var user = await _userService.RegisterUser(registerUserDto);
            
            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
    }
}