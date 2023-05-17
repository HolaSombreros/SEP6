namespace MovieManagement.Functions.Users; 

public class DeleteUser {
    private readonly IUserService _userService;

    public DeleteUser(IUserService userService) {
        _userService = userService;
    }

    [FunctionName("DeleteUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Delete), Route = "DeleteUser/{userId}")] HttpRequest req, [FromRoute]string userId, ILogger log) {
        try 
        {
            log.LogInformation("C# HTTP trigger function processed a request");
            var guid = Guid.Parse(userId);
            await _userService.DeleteUser(guid);
            log.LogInformation("Deleted user with id " + userId);
            return new OkResult();
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}