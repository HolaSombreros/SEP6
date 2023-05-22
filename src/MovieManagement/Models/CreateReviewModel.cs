using MovieManagement.Attributes;

namespace MovieManagement.Models;

public class CreateReviewModel
{
    [Required(ErrorMessage = "A rating is required")]
    [Range(1, 10, ErrorMessage = "A rating must be between {1} and {2}")]
    public int Rating { get; set; }

    [OptionalStringLength(500, MinimumLength = 3, ErrorMessage = "If present, a review must be between {2} and {1} characters")]
    public string? Review { get; set; }
}
