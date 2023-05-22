namespace MovieManagement.Database.Repositories; 

public interface IUserRepository: IRepository<UserEntity?> {
    Task<UserEntity?> GetByEmailAsync(string email); 
    Task<UserEntity?> GetByUsernameAsync(string username);
    Task<IList<UserEntity?>> GetUsersAsync(IList<Guid> ids);
}