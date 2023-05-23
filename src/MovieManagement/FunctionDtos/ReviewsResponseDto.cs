namespace MovieManagement.FunctionDtos;

public class ReviewsResponseDto
{
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public IList<ReviewResponseDto> MovieRatingDtos { get; set; } = default!;
}
