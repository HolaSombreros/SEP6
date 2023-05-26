namespace MovieManagement.Functions.Validators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre id must be provided");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
    }
}