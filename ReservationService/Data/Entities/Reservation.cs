namespace ReservationService.Data.Entities;
//pojedyncza rezerwacja
public class Reservation
{
    public int Id {get; set;}
    public int UserId { get; set; }
     public int AppointmentTypeId { get; set; }
    public DateTime Time { get; set; }
    public User User { get; set; } = null!;
    public AppointmentType AppointmentType { get; set; } = null!;

}