namespace ReservationService.Data.Repositories;

using ReservationService.Data.Entities;

public class AppointmentTypesRepository : IAppointmentTypeRepository
{
    private readonly AppDbContext _context;

    public AppointmentTypesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AppointmentType?> GetById(int id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task Add(AppointmentType appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task Reschedule(AppointmentType appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(AppointmentType appointment)
    {
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }
}