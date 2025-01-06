using AutoLend.Core.ApiModels.Reservation;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {
        /// <summary>
        /// Endpoint to update an existing reservation by its ID.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <param name="reservation"></param>
        /// <returns></returns>
        [HttpPut("{reservationId}")]
        public async Task<IActionResult> Update( [FromRoute] int reservationId, [FromBody] ReservationUpdateRequest reservation ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _reservationService.UpdateReservation(reservationId, reservation);
                return Ok("Reservation updated");
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
