using ReservationService.Data.Entities;

namespace ReservationService.Data.Repositories;
public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetReservations();
    Task<Reservation> GetReservationById(int id);
    Task AddReservation(Reservation reservation);
    Task UpdateReservation(Reservation reservation);
    Task DeleteReservation(int id);
}