using AutoLend.Domain.DataModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> Delete([FromRoute] int reservationId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _reservationService.DeleteReservation(reservationId);
                return Ok("Reservation removed");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
