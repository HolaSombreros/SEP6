namespace MovieManagement.Functions.Users; 

public class LoginUser {
    private readonly IUserService _userService;

    public LoginUser(IUserService userService) {
        _userService = userService;
    }

    [FunctionName("LoginUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        try {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        
            var loginUserDto = JsonConvert.DeserializeObject<LoginUserDto>(requestBody);

            var user = await _userService.GetUser(loginUserDto);

            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
       
    }
}