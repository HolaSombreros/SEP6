﻿namespace MovieManagement.Components.Reviews;

public partial class RatingView : ComponentBase
{
    [Parameter]
    public int RatingNumber { get; set; }

    [Parameter]
    public bool IsActive { get; set; }

    private string CssClass => IsActive ? "active" : "";
}
