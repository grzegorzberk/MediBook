using ReservationService.Data.Entities;

namespace ReservationService.Data.Repositories;
public interface IUserRepository
{
    Task<User> GetUserById(Guid id);
    Task AddUser(User user);
    // inne metody CRUD
}
