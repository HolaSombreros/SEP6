namespace MovieManagement.Functions.Validators;

public class MovieRatingDtoValidator : AbstractValidator<MovieRatingDto>
{
    public MovieRatingDtoValidator()
    {
        RuleFor(x => x.Rating).InclusiveBetween(1, 10).WithMessage("Rating must be between 1 and 10");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id must be provided");
        RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie id must be provided");
    }
}