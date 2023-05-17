namespace MovieManagement.Functions.Dtos;

public class RatingDto
{
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string Review { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public Guid UserId { get; set; }
}