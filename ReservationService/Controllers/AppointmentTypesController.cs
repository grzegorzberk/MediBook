namespace ReservationService.Controllers;

using Microsoft.AspNetCore.Mvc;
using ReservationService.Data.Entities;
using ReservationService.Data.Repositories;

[Route("api/[controller]")]
[ApiController]
public class AppointmentTypesController : ControllerBase
{
    private readonly IAppointmentTypeRepository _appointmentTypesRepository;

    public AppointmentTypesController(IAppointmentTypeRepository appointmentTypesRepository)
    {
        _appointmentTypesRepository = appointmentTypesRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentType>> GetAppointmentTypesById(int id)
    {
        var appointment = await _appointmentTypesRepository.GetById(id);
        if (appointment == null)
            return NotFound();
        return appointment;
    }

    [HttpPost]
    public async Task<ActionResult> AddAppointment(AppointmentType appointment)
    {
        await _appointmentTypesRepository.Add(appointment);
        return CreatedAtAction(nameof(GetAppointmentTypesById), new { id = appointment.Id }, appointment);
    }
}