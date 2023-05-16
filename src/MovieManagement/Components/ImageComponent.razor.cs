namespace MovieManagement.Components;

public partial class ImageComponent : ComponentBase
{
    [Parameter] 
    public string ImageUrl { get; set; } = default!;
}