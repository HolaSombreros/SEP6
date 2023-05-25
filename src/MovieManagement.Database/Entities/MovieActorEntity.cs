namespace MovieManagement.Database.Entities; 

public class MovieActorEntity {
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    public int MovieOrder { get; set; }
    public virtual ActorEntity ActorEntity { get; set; } = default!;
    public virtual MovieEntity MovieEntity { get; set; } = default!;
}