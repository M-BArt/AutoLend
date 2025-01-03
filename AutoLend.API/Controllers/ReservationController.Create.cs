using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.DataModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Reservation reservation) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _reservationService.CreateReservation(reservation);
                return Ok("Reservation added successfully.");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
