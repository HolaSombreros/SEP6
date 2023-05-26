using MovieManagement.Functions.Dtos;
using GenreDto = MovieManagement.Functions.Dtos.GenreDto;

namespace MovieManagement.Test.MovieTests;
[TestFixture]
public class ValidatorTests
{
    private GenreDtoValidator _genreValidator;
    private UserDtoValidator _userValidator;

    [SetUp]
    public void Setup()
    {
        _genreValidator = new GenreDtoValidator();
        _userValidator = new UserDtoValidator();
    }

    /// <summary>
    /// Unit tests for some validators to check receiving dtos
    /// For more, check: https://docs.fluentvalidation.net/en/latest/testing.html
    /// </summary>
    [Test]
    public void GenreName_ShouldHaveValidationError_WhenNull()
    {
        // Arrange
        var genre = new GenreDto { GenreId = 0, Name = null };

        // Act
        var result = _genreValidator.TestValidate(genre);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name must be provided");
    }
    
    [Test]
    public void GenreName_ShouldHaveValidationError_WhenEmpty()
    {
        // Arrange
        var genre = new GenreDto { GenreId = 1, Name = string.Empty };

        // Act
        var result = _genreValidator.TestValidate(genre);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name must be provided");
    }
    
    [Test]
    public void UserEmail_ShouldHaveValidationError_WhenExceedsMaxLength()
    {
        // Arrange
        var userDto = new UserDto { Email = "hshahoproduction1585187542101@johnatdoeatjunior.com",
            Username = "john", Password = "password123" };

        // Act
        var result = _userValidator.TestValidate(userDto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email length cannot exceed 50 characters");
    }
    
    [Test]
    public void UserEmail_ShouldHaveValidationError_WhenInvalidFormat()
    {
        // Arrange
        var userDto = new UserDto { Email = "notavalidemail", Username = "john", Password = "password123" };

        // Act
        var result = _userValidator.TestValidate(userDto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email must be a valid email address");
    }
    
    [Test]
    public void UserUsername_ShouldHaveValidationError_WhenEmpty()
    {
        // Arrange
        var userDto = new UserDto { Email = "john@example.com", Username = string.Empty, Password = "password123" };

        // Act
        var result = _userValidator.TestValidate(userDto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Username)
            .WithErrorMessage("Username must be provided");
    }
    
    [Test]
    public void UserUsername_ShouldHaveValidationError_WhenBelowMinLength()
    {
        // Arrange
        var userDto = new UserDto { Email = "john@example.com", Username = "jo", Password = "password123" };

        // Act
        var result = _userValidator.TestValidate(userDto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Username)
            .WithErrorMessage("Your username length must be at least 3.");
    }
    
    [Test]
    public void UserPassword_ShouldHaveValidationError_WhenBelowMinLength()
    {
        // Arrange
        var userDto = new UserDto { Email = "john@example.com", Username = "john", Password = "pass" };

        // Act
        var result = _userValidator.TestValidate(userDto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage("Your password length must be at least 6.");
    }
}