using MovieManagement.Attributes;

namespace MovieManagement.ViewModels.Rating;

public class RatingViewModel
{
    [Required(ErrorMessage = "A rating is required")]
    [Range(2, 10, ErrorMessage = "A rating must be between {2} and {1}")]
    public int? StarRating { get; set; }

    [OptionalStringLength(500, MinimumLength = 3, ErrorMessage = "If present, a review must be between {2} and {1} characters")]
    public string? Review { get; set; }
}