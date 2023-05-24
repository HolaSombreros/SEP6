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
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Put), Route = null)] HttpRequest req, ILogger log,
        [Sql(commandText: "dbo.User", connectionStringSetting: "DbConnectionString")] IAsyncCollector<UserEntity> userTable) {
        try 
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDto = JsonConvert.DeserializeObject<UserDto>(requestBody);
            
            var result = await _validator.ValidateAsync(userDto!);
            if (!result.IsValid)
            {
                log.LogInformation("Body request not valid" + result.Errors[0].ErrorMessage);
                return new BadRequestObjectResult(result.Errors);
            }
            var user = await _userService.UpdateUser(userDto!);
            log.LogInformation("User with id: {id} has been updated ", user.UserId);
            return new OkObjectResult(user);
        }
        catch (Exception e) 
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}