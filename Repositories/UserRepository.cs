using c_sharp.Models.User;
using c_sharp.Contracts;
using c_sharp.Data;
using Microsoft.EntityFrameworkCore;

namespace c_sharp.Repositories;

public class UserRepository : IUserContract
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

        public async Task<User> CreateUser(CreateUserDto createUser)
        {
            var user = new User
            {
                Email = createUser.Email,
                HashPassword = HashPassword(createUser.Password),
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> VerifyUserPassword(LoginUserDto loginUser)
        {
            var user = await GetUserByEmail(loginUser.Email);
            if (user == null) return false;

            var result = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.HashPassword);
            Console.WriteLine(result);

            return result;
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
}