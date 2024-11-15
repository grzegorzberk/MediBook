namespace ReservationService.Data.Repositories;

using ReservationService.Data.Entities;

public interface IAppointmentTypeRepository
{
    Task<AppointmentType?> GetById(int id);
    Task Add(AppointmentType appointmentType);
    Task Delete(AppointmentType appointmentType);
    Task Reschedule(AppointmentType appointmentType);
}
