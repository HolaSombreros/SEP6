namespace MovieManagement.Functions.Users; 

public class DeleteUser {
    private readonly IUserService _userService;

    public DeleteUser(IUserService userService) {
        _userService = userService;
    }

    [FunctionName("DeleteUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req, ILogger log) {
        try 
        {
            log.LogInformation("C# HTTP trigger function processed a request");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var userId = JsonConvert.DeserializeObject<DeleteUserDto>(requestBody);
            
            await _userService.DeleteUser(userId.Id);
            log.LogInformation("Deleted user with id " + userId);
            return new OkResult();
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
        
    }
}