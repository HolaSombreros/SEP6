namespace MovieManagement.Functions.Services; 

public class UserService : IUserService {

    private readonly IMapper _mapper;
    private readonly MoviemanagementDbContext _context;


    public UserService(IMapper mapper, MoviemanagementDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    private async Task<UserEntity> GetUser(RegisterUserDto registerUserDto) {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(registerUserDto.Email) && !u.IsDeleted);
        return user;
    }

    public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto) {
        if (await GetUser(registerUserDto) != null)
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