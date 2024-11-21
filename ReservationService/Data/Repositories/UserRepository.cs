using Microsoft.EntityFrameworkCore;
using ReservationService.Data.Entities;
namespace ReservationService.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}