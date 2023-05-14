namespace MovieManagement.Domain.Models;

public class Rating
{
    public Guid RatingId { get; set; }
    public string Review { get; set; }  = default!;
    public int StarRating { get; set; }
}