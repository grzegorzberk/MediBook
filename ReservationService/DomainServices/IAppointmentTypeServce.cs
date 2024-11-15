namespace ReservationService.DomainServices;

using ReservationService.Data.Entities;

public interface IAppointmentTypeService 
{
    public Task Add(AppointmentType appointment);
    public Task Delete(AppointmentType appointment);
    public Task Reschedule(AppointmentType appointment);
}