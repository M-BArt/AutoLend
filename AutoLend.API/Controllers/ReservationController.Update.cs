using AutoLend.Domain.DataModels.Rental;
using AutoLend.Domain.DataModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        [HttpPut("{reservationId}")]
        public async Task<IActionResult> Update( [FromBody] Reservation reservation, [FromRoute] int reservationId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _reservationService.UpdateReservation(reservation);
                return Ok("Reservation updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
