namespace MovieManagement.Functions.Validators;

public class MovieDtoValidator : AbstractValidator<MovieDto>
{
    public MovieDtoValidator()
    {
        RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie id must be provided");
        RuleFor(x => x.Genres).NotNull().SetValidator(new GenreListValidator()).WithMessage("Genres must be provided");
    }
}