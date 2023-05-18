namespace MovieManagement.Functions.Dtos;

public class RatingQueryDto
{
    public int MovieId { get; set; }
    public double Average { get; set; }
    public int VoteCount { get; set; }
}