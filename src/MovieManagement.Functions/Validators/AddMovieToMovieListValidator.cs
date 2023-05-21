namespace MovieManagement.Functions.Validators;

public class AddMovieToMovieListValidator : AbstractValidator<MovieToMovieListDto>
{
    public AddMovieToMovieListValidator()
    {
        RuleFor(request => request.MovieListId).NotEmpty();
        RuleFor(request => request.MovieId).NotEmpty();
    }
}