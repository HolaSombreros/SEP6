namespace MovieManagement.Shared;

public partial class ImageComponent : ComponentBase
{
   [Parameter] public string ImageUrl { get; set; } = default!;
}