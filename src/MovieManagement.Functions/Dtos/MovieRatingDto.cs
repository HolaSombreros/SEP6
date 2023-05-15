namespace MovieManagement.Functions.Dtos;

public class MovieRatingDto
{
    public int MovieId { get; set; }
    [Range(1,10)]
    public int Rating { get; set; }
    public string Review { get; set; } = default!;
    public DateTime DateTime { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public Guid UserId { get; set; }
}