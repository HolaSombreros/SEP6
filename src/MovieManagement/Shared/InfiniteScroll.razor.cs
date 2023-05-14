using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MovieManagement.Shared;

public partial class InfiniteScroll : ComponentBase
{
  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;

  [Parameter]
  public string ObservableTargetId { get; set; } = default!;

  [Parameter]
  public EventCallback<bool> ObservableTargetReached { get; set; }
  private DotNetObjectReference<InfiniteScroll> objectRef = default!;

  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      objectRef = DotNetObjectReference.Create(this);
      await JSRuntime.InvokeAsync<dynamic>("Observer.Initialize", objectRef, ObservableTargetId);
    }
  }

  [JSInvokable]
  public async Task OnIntersection()
  {
    await ObservableTargetReached.InvokeAsync(true);
  }
}

