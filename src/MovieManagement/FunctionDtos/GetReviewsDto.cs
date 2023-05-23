namespace MovieManagement.FunctionDtos;

public class GetReviewsDto
{
    public int MovieId { get; set; }
    public Guid? UserGuid { get; set; }

    public GetReviewsDto(int movieId, Guid? userGuid)
    {
        MovieId = movieId;
        UserGuid = userGuid;
    }
}
