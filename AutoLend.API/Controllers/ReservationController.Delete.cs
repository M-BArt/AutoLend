using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers
{
    public partial class ReservationController
    {
        /// <summary>
        /// Endpoint to delete an existing reservation by its ID.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> Delete([FromRoute] int reservationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _reservationService.DeleteReservation(reservationId);
                return Ok("Reservation removed");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);

                return ex switch {
                    BusinessException => BadRequest(ex.Message),
                    _ => StatusCode(500, "Internal Error Server")
                };
            }
        }
    }
}
