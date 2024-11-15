using ReservationService.Controllers;
using ReservationService.Data.Entities;
using ReservationService.Data.Repositories;

namespace ReservationService.DomainServices;

public class AppointmentTypeService : IAppointmentTypeService
{
    private readonly IAppointmentTypeRepository _appointmentRepository;

    public AppointmentTypeService(IAppointmentTypeRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public async Task Add(AppointmentType appointment)
    {
        await _appointmentRepository.Add(appointment);
    }

    public async Task Delete(AppointmentType appointment)
    {
        await _appointmentRepository.Delete(appointment);
    }

    public async Task Reschedule(AppointmentType appointment)
    {
        await _appointmentRepository.Reschedule(appointment);
    }
}
