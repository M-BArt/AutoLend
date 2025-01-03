using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        [HttpGet("{reservationId}")]
        public async Task<IActionResult> Get( [FromRoute] int reservationId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                return Ok(await _reservationService.GetReservationById(reservationId));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
