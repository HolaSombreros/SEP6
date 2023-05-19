namespace MovieManagement.Functions.Dtos;

public class AddMovieToMovieListDto
{
    public Guid MovieListId { get; set; }
    public int MovieId { get; set; }
}