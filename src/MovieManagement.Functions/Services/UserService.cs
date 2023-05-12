using MovieManagement.Database.Context;

namespace MovieManagement.Functions.Services; 


public class UserService : IUserService {

    private readonly IMapper _mapper;
    private readonly MovieManagementDbContext _context;


    public UserService(IMapper mapper, MovieManagementDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    public async Task<UserDto> GetUser(LoginUserDto loginUserDto) {
        var user = await Get(loginUserDto.Email);
        return user.Password.Equals(loginUserDto.Password) ? _mapper.Map<UserDto>(user) : null;
    }

    private async Task<UserEntity> Get(string email) {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && !u.IsDeleted);
        return user;
    }

    public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto) {
        if (await Get(registerUserDto.Email) != null)
            return null;
        var user = _mapper.Map<UserEntity>(registerUserDto);
        user.UserId = new Guid();
        user.IsDeleted = false;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}