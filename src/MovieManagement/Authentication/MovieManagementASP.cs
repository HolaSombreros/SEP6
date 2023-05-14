namespace MovieManagement.Authentication;

public class MovieManagementASP : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IUserService _userService;
    private UserViewModel _cached = default!;

    public MovieManagementASP(IJSRuntime jsRuntime, IUserService userService)
    {
        _jsRuntime = jsRuntime;
        _userService = userService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();

        if (_cached == default!)
        {
            var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");

            if (!string.IsNullOrEmpty(json))
            {
                _cached = JsonSerializer.Deserialize<UserViewModel>(json) ?? default!;
                identity = SetupClaims(_cached);
            }
        }
        else
        {
            identity = SetupClaims(_cached);
        }

        var cachedPrincipal = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(cachedPrincipal));
    }

    public async Task LoginAsync(UserViewModel user)
    {
        if (string.IsNullOrWhiteSpace(user.Email)) throw new Exception("Please specify your email address");
        if (string.IsNullOrWhiteSpace(user.Password)) throw new Exception("Please specify your password");

        var identity = new ClaimsIdentity();
        
        user = await _userService.LoginUserAsync(user);
        identity = SetupClaims(user);
        var data = JsonSerializer.Serialize(user);
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", data);
        _cached = user;


        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }
    
    public async Task LogoutAsync()
    {
        _cached = default!;
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    private ClaimsIdentity SetupClaims(UserViewModel user)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim("Id", user.UserId.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, user.Username));

        var identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }
}