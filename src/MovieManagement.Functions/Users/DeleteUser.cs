namespace MovieManagement.Functions.Users; 

public class DeleteUser {
    private readonly IUserService _userService;

    public DeleteUser(IUserService userService) {
        _userService = userService;
    }

    [FunctionName("DeleteUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous,  nameof(HttpMethods.Delete), Route = "DeleteUser/{userId}")] HttpRequest req, [FromRoute]Guid userId, ILogger log) {
        try 
        {
            log.LogInformation("C# HTTP trigger function processed a request");
            await _userService.DeleteUser(userId);
            log.LogInformation("Deleted user with id " + userId);
            return new OkResult();
        }
        catch (Exception e) 
        {
            log.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}