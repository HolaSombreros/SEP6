﻿namespace MovieManagement.TMDB.Api.Dtos;

public class DatePeriodDto
{
    [JsonPropertyName("maximum")]
    public DateTime PeriodTo { get; set; } = default!;

    [JsonPropertyName("minimum")]
    public DateTime PeriodFrom { get; set; } = default!;
}