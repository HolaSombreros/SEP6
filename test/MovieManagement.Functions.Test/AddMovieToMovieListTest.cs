using MovieManagement.Functions.MovieList;

namespace MovieManagement.Functions.Test;

[TestFixture]
internal class AddMovieToMovieListTest : HttpRequestMockTestHelper
{
    private AddMovieToMovieList uut;

    private IValidator<MovieToMovieListDto> movieListValidatorMock;
    private IValidator<MovieDto> movieDtoValidatorMock;
    private IMovieService movieServiceMock;
    private IMovieListMovieService movieListMovieServiceMock;
    private IGenreService genreServiceMock;
    private IMovieGenreService movieGenreServiceMock;
    private ILogger loggerMock;

    [SetUp]
    public void SetUp()
    {
        movieListValidatorMock = Substitute.For<IValidator<MovieToMovieListDto>>();
        movieDtoValidatorMock = Substitute.For<IValidator<MovieDto>>();
        movieServiceMock = Substitute.For<IMovieService>();
        movieListMovieServiceMock = Substitute.For<IMovieListMovieService>();
        genreServiceMock = Substitute.For<IGenreService>();
        movieGenreServiceMock = Substitute.For<IMovieGenreService>();
        loggerMock = Substitute.For<ILogger>();

        movieServiceMock.AddMovieAsync(Arg.Any<MovieDto>()).Returns(new MovieDto
        {
            MovieId = default
        });

        uut = new AddMovieToMovieList(movieListValidatorMock, movieDtoValidatorMock, movieServiceMock, movieListMovieServiceMock, genreServiceMock, movieGenreServiceMock);
    }

    [Test]
    public async Task AddMovieToMovieList_ValidationSucceeds_ReturnsHttpOk()
    {
        // Arrange
        SetSuccessfulValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        var result = await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        Assert.IsTrue(result is OkObjectResult);
    }

    [Test]
    public async Task AddMovieToMovieList_MovieToMovieListDtoValidationFails_ReturnsHttpBadRequest()
    {
        // Arrange
        SetFailedMovieToMovieListDtoValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        var result = await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
    }

    [Test]
    public async Task AddMovieToMovieList_MovieDtoValidationFails_ReturnsHttpBadRequest()
    {
        // Arrange
        SetFailedMovieDtoValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        var result = await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
    }

    [Test]
    public async Task AddMovieToMovieList_ValidationSucceeds_CallsServicesToInsertMovieAndGenres()
    {
        // Arrange
        SetSuccessfulValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        await movieServiceMock.Received().AddMovieAsync(Arg.Any<MovieDto>());
        await genreServiceMock.Received().AddGenreAsync(Arg.Any<List<GenreDto>>());
        await movieGenreServiceMock.Received().AddMovieGenreAsync(Arg.Any<List<GenreDto>>(), Arg.Any<int>());
        await movieListMovieServiceMock.Received().AddMovieToMovieListAsync(Arg.Any<MovieToMovieListDto>());
    }

    [Test]
    public async Task AddMovieToMovieList_MovieToMovieListDtoValidationFails_DoesNotCallServicesToInsertMovieAndGenres()
    {
        // Arrange
        SetFailedMovieToMovieListDtoValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        await movieServiceMock.DidNotReceive().AddMovieAsync(Arg.Any<MovieDto>());
        await genreServiceMock.DidNotReceive().AddGenreAsync(Arg.Any<List<GenreDto>>());
        await movieGenreServiceMock.DidNotReceive().AddMovieGenreAsync(Arg.Any<List<GenreDto>>(), Arg.Any<int>());
        await movieListMovieServiceMock.DidNotReceive().AddMovieToMovieListAsync(Arg.Any<MovieToMovieListDto>());
    }

    [Test]
    public async Task AddMovieToMovieList_MovieDtoValidationFails_DoesNotCallServicesToInsertMovieAndGenres()
    {
        // Arrange
        SetFailedMovieDtoValidation();

        var requestDto = GetMovieDto();
        var httpRequestMock = GetMockedHttpRequest(requestDto);
        var movieListId = new Guid();

        // Act
        await uut.RunAsync(httpRequestMock, movieListId, loggerMock);

        // Assert
        await movieServiceMock.DidNotReceive().AddMovieAsync(Arg.Any<MovieDto>());
        await genreServiceMock.DidNotReceive().AddGenreAsync(Arg.Any<List<GenreDto>>());
        await movieGenreServiceMock.DidNotReceive().AddMovieGenreAsync(Arg.Any<List<GenreDto>>(), Arg.Any<int>());
        await movieListMovieServiceMock.DidNotReceive().AddMovieToMovieListAsync(Arg.Any<MovieToMovieListDto>());
    }

    private void SetSuccessfulValidation()
    {
        movieListValidatorMock.ValidateAsync(Arg.Any<MovieToMovieListDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>()
        });

        movieDtoValidatorMock.ValidateAsync(Arg.Any<MovieDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>()
        });
    }

    private void SetFailedMovieToMovieListDtoValidation()
    {
        movieListValidatorMock.ValidateAsync(Arg.Any<MovieToMovieListDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure()
            }
        });

        movieDtoValidatorMock.ValidateAsync(Arg.Any<MovieDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>()
        });
    }

    private void SetFailedMovieDtoValidation()
    {
        movieListValidatorMock.ValidateAsync(Arg.Any<MovieToMovieListDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>()
        });

        movieDtoValidatorMock.ValidateAsync(Arg.Any<MovieDto>()).Returns(new ValidationResult
        {
            Errors = new List<ValidationFailure>
            {
                new ValidationFailure()
            }
        });
    }

    private MovieDto GetMovieDto()
    {
        return new MovieDto
        {
            MovieId = default,
            Genres = new List<GenreDto>()
        };
    }
}
