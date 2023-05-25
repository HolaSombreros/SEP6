namespace MovieManagement.Components;

public partial class InfiniteScroll : ComponentBase, IDisposable
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
    public async Task OnIntersectionAsync()
    {
        await ObservableTargetReached.InvokeAsync(true);
    }

    public void Dispose()
    {
        objectRef?.Dispose();
    }
}
