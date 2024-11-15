namespace ReservationService.ViewModels;
public class AppointmentViewModel
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public TimeSpan Duration {get; set;}
    public decimal Price {get; set;}
}