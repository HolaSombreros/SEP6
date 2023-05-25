namespace MovieManagement.Models;

public class RatingsByGenreRequestModel
{
    [Required]
    public int? GenreId { get; set; }
}
