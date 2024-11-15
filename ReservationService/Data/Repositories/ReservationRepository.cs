
using Microsoft.EntityFrameworkCore;
using ReservationService.Data.Entities;

namespace ReservationService.Data.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;
    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddReservation(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteReservation(int id)
    {
        var reservation = await GetReservationById(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Reservation> GetReservationById(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<IEnumerable<Reservation>> GetReservations()
    {
        return await _context.Reservations.Include(r => r.User).Include(r => r.AppointmentType).ToListAsync();
    }

    public async Task UpdateReservation(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }
}