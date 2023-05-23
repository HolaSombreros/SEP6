namespace MovieManagement.Models;

public class PaginatedReviewsModel
{
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public List<ReviewModel> Reviews { get; set; } = new();

    public PaginatedReviewsModel(ReviewsResponseDto dto)
    {
        TotalPages = dto.TotalPages;
        Page = dto.Page;

        foreach (var reviewDto in dto.MovieRatingDtos)
        {
            Reviews.Add(new ReviewModel(reviewDto));
        }
    }
}
