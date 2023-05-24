namespace MovieManagement.Functions.Validators; 

public class AddMovieListValidator : AbstractValidator<AddMovieListDto> {
    public AddMovieListValidator() {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id must be provided");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title must be provided")
            .MinimumLength(1).WithMessage("Title must be at least 1 character")
            .MaximumLength(50).WithMessage("Title length must not exceed 50.");
    }
}