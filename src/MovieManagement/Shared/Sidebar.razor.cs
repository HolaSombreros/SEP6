using Microsoft.AspNetCore.Components;
using MovieManagement.Data;
using MovieManagement.Models.Index;

namespace MovieManagement.Shared;

public partial class Sidebar
{
  [Inject]
  public NavigationManager NavigationManager { get; set; } = default!;
  private bool hideSidebar = true;
  private string? SidebarCssClass => hideSidebar ? "hide-sidebar" : null;
  private List<MovieListViewModel>? customMovieLists;

  protected override async Task OnInitializedAsync()
  {
    customMovieLists = await DummyData.GetCustomMovieLists();
    // TODO - Implement me.
  }

  private void ToggleSidebar()
  {
    hideSidebar = !hideSidebar;
  }

  private void CreateNewMovieList()
  {
    // TODO - Implement me.
  }
}