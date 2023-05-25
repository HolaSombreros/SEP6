namespace MovieManagement.Functions.Validators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(x => x.GenreId).NotNull().WithMessage("Genre id must be provided");
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name must be provided");
    }
}