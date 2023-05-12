namespace MovieManagement.Database.Repositories; 

public class UserRepository : IUserRepository {
    private readonly MovieManagementDbContext _context;

    public UserRepository(MovieManagementDbContext context) {
        _context = context;
    }

    public async Task<UserEntity?> GetAsync(Guid id) {
        throw new NotImplementedException();
    }

    public async Task<UserEntity?> AddAsync(UserEntity entity) {
        throw new NotImplementedException();
    }

    public async Task<UserEntity?> UpdateAsync(UserEntity entity) {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> DeleteAsync(Guid id) {
        throw new NotImplementedException();
    }

    public async Task<UserEntity?> GetByEmail(string email) {
        return await _context.Users.FirstOrDefaultAsync(u => u!.Email.Equals(email));
    }
}