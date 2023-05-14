﻿namespace MovieManagement.Functions.Users;

public class RegisterUser {
    private readonly IUserService _userService;

    public RegisterUser(IUserService userService) {
        _userService = userService;
    }

    [FunctionName("RegisterUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP received user dto");
        
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var registerUserDto = JsonConvert.DeserializeObject<RegisterUserDto>(requestBody);
        var user = await _userService.RegisterUser(registerUserDto);
        
        return new OkObjectResult(user);
    }
}