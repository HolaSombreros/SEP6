namespace MovieManagement.TMDB.Api.Dtos;

public class ProductionCompanyDto
{
    public string Name { get; set; } = default!;
    [JsonPropertyName("origin_country")]
    public string Country { get; set; } = default!;
}