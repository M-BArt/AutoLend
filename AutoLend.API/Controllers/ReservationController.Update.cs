using AutoLend.Core.ApiModels.Reservation;
using AutoLend.Data.DataModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers
{
    public partial class ReservationController
    {
        [HttpPut("{reservationId}")]
        public async Task<IActionResult> Update( [FromRoute] int reservationId, [FromBody] ReservationUpdateRequest reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _reservationService.UpdateReservation(reservationId, reservation);
                return Ok("Reservation updated");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Reservation not found or is not active.")){
                    return BadRequest("Reservation not found or is not active.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
