namespace MovieManagement.Services;

public interface IMovieListService
{
    List<MovieListViewModel> GetCurrentUserLists();
    MovieListViewModel GetCustomList(Guid listId);
    Task CreateCustomListAsync(MovieListViewModel list);
    Task DeleteCustomListAsync(Guid id);
    Task AddMovieToListAsync(Guid listId, MovieViewModel movie);
    Task DeleteMovieFromListAsync(Guid listId, MovieViewModel movie);
    Task GetUserListsAsync(Guid userId);
    event Action OnChanged;
}