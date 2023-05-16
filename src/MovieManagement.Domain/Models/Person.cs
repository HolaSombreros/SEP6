namespace MovieManagement.Domain.Models;

public class Person
{
    public int Id { get; set; }
    public DateTime Birthday { get; set; }
    public string Name { get; set; } = default!;
    public string Biography { get; set; } = default!;
    public DateTime? DeathDay { get; set; }
    public string PlaceOfBirth { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public double Popularity { get; set; }
}