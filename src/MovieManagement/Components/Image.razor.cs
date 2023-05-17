namespace MovieManagement.Components;

public partial class Image : ComponentBase
{
    [Parameter] 
    public string ImageUrl { get; set; } = default!;
}