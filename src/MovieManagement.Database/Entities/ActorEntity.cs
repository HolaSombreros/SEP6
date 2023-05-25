namespace MovieManagement.Database.Entities; 

[Table("Actor")]
public class ActorEntity {
    [Key]
    public int ActorId { get; set; }
    public int Gender { get; set; }
    public DateTime? Birthdate { get; set; }
    public string Name { get; set; } = default!;
}