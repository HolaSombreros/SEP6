namespace MovieManagement.Functions.Validators;

public class RatingDtoValidator : AbstractValidator<RatingDto>
{
    public RatingDtoValidator()
    {
        RuleFor(x => x.Rating).NotEmpty().InclusiveBetween(1, 10).WithMessage("Rating must be between 1 and 10");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id must be provided");
        RuleFor(x => x.MovieDto).NotNull().SetValidator(new MovieDtoValidator()).WithMessage("Movie id must be provided");
    }
}