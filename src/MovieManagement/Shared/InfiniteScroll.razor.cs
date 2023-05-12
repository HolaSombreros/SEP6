using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MovieManagement.Shared;

public partial class InfiniteScroll : ComponentBase
{
  [Inject]
  public IJSRuntime JSRuntime { get; set; }

  [Parameter]
  public RenderFragment ChildContent { get; set; }

  [Parameter]
  public string ObservableTargetId { get; set; }

  [Parameter]
  public EventCallback<bool> ObservableTargetReached { get; set; }

  private DotNetObjectReference<InfiniteScroll> objectRef;

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

