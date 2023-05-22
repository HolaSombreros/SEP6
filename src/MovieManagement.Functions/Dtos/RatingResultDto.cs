namespace MovieManagement.Functions.Dtos;

public class RatingResultDto
{
    public int Page { get; set; }
    public int TotalResult { get; set; }
    public IList<MovieRatingDto> MovieRatingDtos { get; set; }
}