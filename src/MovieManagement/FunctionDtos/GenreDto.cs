namespace MovieManagement.FunctionDtos;

public class GenreDto
{
    public int GenreId { get; set; }
    public string Name { get; set; }

    public GenreDto(int genreId, string name)
    {
        GenreId = genreId;
        Name = name;
    }
}
