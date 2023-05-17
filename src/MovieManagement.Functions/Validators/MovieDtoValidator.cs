namespace MovieManagement.Functions.Validators;

public class MovieDtoValidator : AbstractValidator<MovieDto>
{
    public MovieDtoValidator()
    {
        RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie id must be provided");
    }
}