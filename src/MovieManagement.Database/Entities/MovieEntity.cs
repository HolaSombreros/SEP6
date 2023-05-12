namespace MovieManagement.Database.Entities;

[Table("Movie")]
public partial class MovieEntity
{
    [Key]
    public int MovieId { get; set; }
}
