namespace MovieManagement.ViewModels;

public class UserViewModel
{
    public Guid UserId { get; set; }
    
    [Required(ErrorMessage = "Please enter a username")]
    [MaxLength(50, ErrorMessage = "The username cannot exceed {1} characters")]
    [MinLength(3, ErrorMessage = "The username has to be at least {1} characters")]
    public string Username { get; set; } = default!;
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter an email address")]
    [EmailAddress(ErrorMessage = "Please enter a valid email")]
    [MaxLength(50, ErrorMessage = "The email cannot exceed {1} characters")]
    public string Email { get; set; } = default!;
    
    [Required(ErrorMessage = "Please enter a password")]
    [MaxLength(50, ErrorMessage = "The password cannot exceed {1} characters")]
    [MinLength(6, ErrorMessage = "The password has to be at least {1} characters")]
    public string Password { get; set; } = default!;

    [Required(ErrorMessage = "Please confirm the password")]
    [Compare("Password", ErrorMessage = "Passwords must match")]
    public string ConfirmPassword { get; set; } = default!;
}