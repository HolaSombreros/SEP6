
namespace MovieManagement.Functions.Users; 

public class EditUser {
    
    private readonly IUserService _userService;

    public EditUser(IUserService userService)
    {
        _userService = userService;
    }
    
    [FunctionName("EditUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log,
        [Sql(commandText: "dbo.User", connectionStringSetting: "DbConnectionString")] IAsyncCollector<UserEntity> userTable) {
        try 
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var registerUserDto = JsonConvert.DeserializeObject<RegisterUserDto>(requestBody);

            var user = await _userService.RegisterUser(registerUserDto);
            
            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}