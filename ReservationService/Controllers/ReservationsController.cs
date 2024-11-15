// namespace ReservationService.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using ReservationService.Data.Entities;

// [Route("api/[controller]")]
// [ApiController]
// public class ReservationController : ControllerBase
// {
//     private readonly ReservationService _reservationRepository;

//     public ReservationController(IReservationService reservationsService)
//     {
//         _reservationService = reservationsService;
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<Reservation>> GetReservationsById(int id)
//     {
//         var appointment = await _reservationsService.GetById(id);
//         if (appointment == null)
//             return NotFound();
//         return appointment;
//     }

//     [HttpPost]
//     public async Task<ActionResult> AddAppointment(Reservation appointment)
//     {
//         await _reservationService.Add(appointment);
//         return CreatedAtAction(nameof(GetReservationsById), new { id = appointment.Id }, appointment);
//     }
// }