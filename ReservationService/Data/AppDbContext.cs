namespace ReservationService.Data;

using Microsoft.EntityFrameworkCore;
using ReservationService.Data.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AppointmentType> Appointments { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
}
