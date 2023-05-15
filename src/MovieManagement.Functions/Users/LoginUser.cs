using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace MovieManagement.Functions.Users; 

public class LoginUser {
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public LoginUser(IUserService userService, IConfiguration configuration) {
        _userService = userService;
        _configuration = configuration;
    }

    [FunctionName("LoginUser")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function,  nameof(HttpMethods.Post), Route = null)] HttpRequest req, ILogger log,
        [Sql(commandText: "SELECT [user_id], [username], [password], [email] FROM dbo.[User] WHERE is_deleted = 0 AND [email]=@Email;", commandType: System.Data.CommandType.Text,
            parameters: "@email={Query.email}", connectionStringSetting: "DbConnectionString")] IEnumerable<UserEntity> users)
    {
        try {
            
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var loginUserDto = JsonConvert.DeserializeObject<LoginUserDto>(requestBody);
            var user = users.FirstOrDefault();
            if (user!.password != loginUserDto.Password) {
                return new BadRequestObjectResult("Wrong password, please try again!");
            }
            
            if (users.IsNullOrEmpty()) {
                return new BadRequestObjectResult("Email not registered");
            }

            return new OkObjectResult(user);
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
       
    }
}