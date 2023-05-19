namespace MovieManagement.Functions.Dtos; 

public class MovieListDto {
    public Guid? MovieListId { get; set; }
    public Guid? UserId { get; set; }
    public string Title { get; set; } = default!;
}