namespace MovieManagement.Functions.Validators; 

public class LoginUserDtoValidator: AbstractValidator<LoginUserDto> {
    public LoginUserDtoValidator() {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be provided").
            EmailAddress().WithMessage("Email must be a valid email address")
            .MaximumLength(50).WithMessage("Email length cannot exceed 50 characters");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be provided")
            .MinimumLength(6).WithMessage("Your password length must be at least 6.")
            .MaximumLength(50).WithMessage("Your password length must not exceed 50.");
    }
}