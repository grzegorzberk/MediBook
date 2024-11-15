namespace ReservationService.Data.Entities;

public class Reservation
{
    public int Id {get; set;}
    public int UserId { get; set; }
    public DateTime Time { get; set; }
     public int AppointmentId { get; set; }
    public User User { get; set; } = null!;
    public AppointmentType AppointmentType { get; set; } = null!;

}