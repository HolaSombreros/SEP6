namespace MovieManagement.Components; 

public partial class DeleteAccount : ComponentBase
{
    private async Task DeleteAsync() {
        var userIdString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        var userId = Guid.Parse(userIdString);
        await UserService.DeleteUserAsync(userId);
        await ((MovieManagementASP) AuthenticationStateProvider).LogoutAsync();
        NavigationManager.NavigateTo("/");
    }
    
}