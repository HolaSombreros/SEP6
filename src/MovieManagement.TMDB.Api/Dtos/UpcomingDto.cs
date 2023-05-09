namespace MovieManagement.TMDB.Api.Dtos;

public class UpcomingDto
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
    public DatePeriodDto? Dates { get; set; }
    [JsonPropertyName("results")]
    public List<MovieDto>? Movies { get; set; }
    public int Page { get; set; }
}