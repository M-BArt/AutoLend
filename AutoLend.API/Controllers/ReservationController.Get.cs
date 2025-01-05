using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        [HttpGet("{reservationId}")]
        public async Task<IActionResult> Get( [FromRoute] int reservationId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                return Ok(await _reservationService.GetReservationById(reservationId));
            } catch (SqlException ex) {
                if (ex.Message.Contains("Reservation not found or is not active.")){
                    return BadRequest("Reservation not found or is not active."); 
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return StatusCode(500, "Internal Error Server");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}