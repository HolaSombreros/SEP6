namespace MovieManagement.Database.Entities;

[Table("Movie")]
public class MovieEntity
{
    [Key]
    public int MovieId { get; set; }
}
