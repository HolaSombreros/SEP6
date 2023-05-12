namespace MovieManagement.TMDB.Api.Dtos;

public class MovieListDto
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
    public DatePeriodDto Dates { get; set; } = default!;
    [JsonPropertyName("results")]
    public List<MovieDto> Movies { get; set; } = default!;
    public int Page { get; set; }
}