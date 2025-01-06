using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class ReservationController {

        /// <summary>
        /// Endpooint to take a reservation by its ID.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [HttpGet("{reservationId}")]
        public async Task<IActionResult> Get( [FromRoute] int reservationId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _reservationService.GetReservationById(reservationId));
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