using MovieManagement.Functions.Ratings;
using MovieManagement.Functions.Services;

namespace MovieManagement.Functions.Test;

internal class AddRatingTest : HttpRequestMockTestHelper
{
    private AddRating uut;

    private IRatingService ratingServiceMock;
    private IValidator<MovieRatingDto> movieRatingDtoValidatorMock;
    private IMovieService movieServiceMock;
    private IGenreService genreServiceMock;
    private IMovieGenreService movieGenreServiceMock;
    private ILogger loggerMock;

    [SetUp]
    public void SetUp()
    {
        ratingServiceMock = Substitute.For<IRatingService>();
        movieRatingDtoValidatorMock = Substitute.For<IValidator<MovieRatingDto>>();
        movieServiceMock = Substitute.For<IMovieService>();
        genreServiceMock = Substitute.For<IGenreService>();
        movieGenreServiceMock = Substitute.For<IMovieGenreService>();
        loggerMock = Substitute.For<ILogger>();

        movieServiceMock.AddMovieAsync(Arg.Any<MovieDto>()).Returns(new MovieDto
        {
            MovieId = default
        });

        ratingServiceMock.PutRatingAsync(Arg.Any<MovieRatingDto>()).Returns(new MovieRatingDto
        {
            RatingId = default
        });

        uut = new AddRating(ratingServiceMock, movieRatingDtoValidatorMock, movieServiceMock, genreServiceMock, movieGenreServiceMock);
    }

    [Test]
    public async Task AddMovieRating_ValidationSucceeds_ReturnsHttpOk()
    {
        // Arrange
        SetSuccessfulValidation();

        var requestDto = GetMovieRatingDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);

        // Act
        var result = await uut.AddUserRating(httpRequestMock, loggerMock);

        // Assert
        Assert.IsTrue(result is OkObjectResult);
    }

    [Test]
    public async Task AddMovieRating_ValidationFails_ReturnsHttpBadRequest()
    {
        // Arrange
        SetFailedValidation();

        var requestDto = GetMovieRatingDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);

        // Act
        var result = await uut.AddUserRating(httpRequestMock, loggerMock);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
    }

    [Test]
    public async Task AddMovieRating_ValidationSucceeds_CallsServicesToInsertMovieAndGenres()
    {
        // Arrange
        SetSuccessfulValidation();

        var requestDto = GetMovieRatingDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);

        // Act
        await uut.AddUserRating(httpRequestMock, loggerMock);

        // Assert
        await movieServiceMock.Received().AddMovieAsync(Arg.Any<MovieDto>());
        await genreServiceMock.Received().AddGenreAsync(Arg.Any<List<GenreDto>>());
        await movieGenreServiceMock.Received().AddMovieGenreAsync(Arg.Any<List<GenreDto>>(), Arg.Any<int>());
        await ratingServiceMock.Received().PutRatingAsync(Arg.Any<MovieRatingDto>());
    }

    private void SetSuccessfulValidation()
    {
        movieRatingDtoValidatorMock.ValidateAsync(Arg.Any<MovieRatingDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>()
        });
    }

    private void SetFailedValidation()
    {
        movieRatingDtoValidatorMock.ValidateAsync(Arg.Any<MovieRatingDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure()
            }
        });
    }

    private MovieRatingDto GetMovieRatingDto()
    {
        return new MovieRatingDto
        {
            Rating = 5,
            Review = "This is a review",
            MovieDto = new()
            {
                Genres = new List<GenreDto>()
            }
        };
    }
}
