namespace MovieManagement.Database.Entities;
[Table("Genre")]
public class GenreEntity
{
    [Key]
    public int GenreId { get; set; }
    public string Name { get; set; } = default!;
}