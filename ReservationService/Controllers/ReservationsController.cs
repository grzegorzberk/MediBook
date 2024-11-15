// namespace ReservationService.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using ReservationService.Data.Entities;
// using ReservationService.Data.Repositories;

// [Route("api/[controller]")]
// [ApiController]
// public class ReservationsController : ControllerBase
// {
//     private readonly IReservationRepository _reservationRepository;

//     public ReservationsController(IReservationRepository reservationRepository)
//     {
//         _reservationRepository = reservationRepository;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
//     {
//         return Ok(await _reservationRepository.GetReservations());
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<Reservation>> GetReservationById(Guid id)
//     {
//         var reservation = await _reservationRepository.GetReservationById(id);
//         if (reservation == null)
//             return NotFound();
//         return reservation;
//     }

//     [HttpPost]
//     public async Task<ActionResult> CreateReservation(Reservation reservation)
//     {
//         await _reservationRepository.AddReservation(reservation);
//         return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
//     }

//     [HttpPut("{id}")]
//     public async Task<ActionResult> UpdateReservation(Guid id, Reservation reservation)
//     {
//         if (id != reservation.Id)
//             return BadRequest();
        
//         await _reservationRepository.UpdateReservation(reservation);
//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult> DeleteReservation(Guid id)
//     {
//         await _reservationRepository.DeleteReservation(id);
//         return NoContent();
//     }
// }