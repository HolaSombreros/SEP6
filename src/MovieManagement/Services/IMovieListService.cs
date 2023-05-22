namespace MovieManagement.Services;

public interface IMovieListService
{
    List<MovieListViewModel> GetCurrentUserLists();
    Task CreateCustomListAsync(MovieListViewModel list);
    Task DeleteCustomListAsync(Guid id);
    Task GetUserListsAsync(Guid id);
    event EventHandler<EventArgs> OnChanged;
}