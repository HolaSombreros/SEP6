namespace MovieManagement.Functions.Validators; 

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto> {
    public RegisterUserDtoValidator() {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be provided").
            EmailAddress().WithMessage("Email must be a valid email address")
            .MaximumLength(50).WithMessage("Email length cannot exceed 50 characters");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username must be provided")
            .MaximumLength(50).WithMessage("Your username length must must not exceed 50.")
            .MinimumLength(3).WithMessage("Your username length must be at least 3.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be provided")
            .MinimumLength(6).WithMessage("Your password length must be at least 6.")
            .MaximumLength(50).WithMessage("Your password length must not exceed 50.");
    }
}