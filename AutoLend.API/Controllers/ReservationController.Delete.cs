using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers
{
    public partial class ReservationController
    {
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> Delete([FromRoute] int reservationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _reservationService.DeleteReservation(reservationId);
                return Ok("Reservation removed");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Reservation not found or is not active.")) {
                    return BadRequest("Reservation not found or is not active.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
