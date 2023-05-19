using MovieManagement.Attributes;

namespace MovieManagement.ViewModels.Rating;

public class RatingViewModel
{
    public Guid? RatingId { get; set; }

    [Required(ErrorMessage = "A rating is required")]
    [Range(1, 10, ErrorMessage = "A rating must be between {1} and {2}")]
    public int StarRating { get; set; }

    [OptionalStringLength(500, MinimumLength = 3, ErrorMessage = "If present, a review must be between {2} and {1} characters")]
    public string? Review { get; set; }
}