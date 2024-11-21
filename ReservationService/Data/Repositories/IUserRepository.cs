using ReservationService.Data.Entities;

namespace ReservationService.Data.Repositories;
public interface IUserRepository
{
    Task<User> GetUserById(int id);
    Task AddUser(User user);
    Task<User> GetUserByEmail(string email);
}
