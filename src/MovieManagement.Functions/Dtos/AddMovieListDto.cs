namespace MovieManagement.Functions.Dtos; 

public class AddMovieListDto {
    public Guid? UserId { get; set; }
    public string Title { get; set; } = default!;
}