﻿namespace MovieManagement.Domain.Models;

public class Credits
{
    public IList<Cast> MovieCast { get; set; } = default!;
    public IList<Crew> MovieCrew { get; set; } = default!;
}