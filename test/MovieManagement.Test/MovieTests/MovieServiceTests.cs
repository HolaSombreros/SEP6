namespace MovieManagement.Test.MovieTests;

[TestFixture]
public class MovieServiceTests
{
    private Mock<IHttpClientFactory> _httpClientFactory;
    private Mock<HttpMessageHandler> _httpMessageHandler;
    private JsonSerializerOptions _jsonSerializerOptions;
    private Mock<IOptions<ApiConfig>> _apiConfig;
    
    [SetUp]
    public void Setup()
    {
        _httpClientFactory = new Mock<IHttpClientFactory>();
        _httpMessageHandler = new Mock<HttpMessageHandler>();
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
        _apiConfig = new Mock<IOptions<ApiConfig>>();

        var apiConfig = new ApiConfig { MovieDatabaseUri = "https://api.themoviedb.org/3/"};
        _apiConfig.Setup(x => x.Value).Returns(apiConfig);

    }

    [Test]
    public void UnauthorizedApiCall_ReturnsEmptyList()
    {
        // Arrange
        _httpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("Unauthorized access")
            });
        var mockHttpClient = new HttpClient(_httpMessageHandler.Object);
        _httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);
        var apiService = new Service(_apiConfig.Object, _httpClientFactory.Object, _jsonSerializerOptions);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<MovieListDto, MovieList>(It.IsAny<MovieListDto>()))
            .Returns(new MovieList { TotalResults = 1} );
        
        var movieService = new MovieService(apiService, mockMapper.Object, _apiConfig.Object);
        
        // Act
        var result = movieService.GetUpcomingMoviesAsync();
        
        // Assert
        Assert.That(result.Result.TotalResults, Is.EqualTo(0));
    }
}