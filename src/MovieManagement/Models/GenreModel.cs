namespace MovieManagement.Models;

public class GenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GenreModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
