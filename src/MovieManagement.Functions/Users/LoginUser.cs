using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        log.LogInformation("C# HTTP received user dto");
        
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        var loginUserDto = JsonConvert.DeserializeObject<LoginUserDto>(requestBody);
        var user = await _userService.GetUser(loginUserDto);
        
        return new OkObjectResult(user);
    }
}