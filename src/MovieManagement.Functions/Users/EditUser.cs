namespace MovieManagement.Functions.Users; 

public class EditUser {
    
    private readonly IUserService _userService;
    private readonly IValidator<UserDto> _validator;

    public EditUser(IUserService userService, IValidator<UserDto> validator) {
        _userService = userService;
        _validator = validator;
    }
    
    [FunctionName("EditUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log,
        [Sql(commandText: "dbo.User", connectionStringSetting: "DbConnectionString")] IAsyncCollector<UserEntity> userTable) {
        try 
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var userDto = JsonConvert.DeserializeObject<UserDto>(requestBody);
            var result = await _validator.ValidateAsync(userDto);
            if (!result.IsValid)
            {
                return new BadRequestObjectResult(result.Errors);
            }
            var user = await _userService.UpdateUser(userDto);
            
            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}