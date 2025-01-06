using AutoLend.Core.ApiModels.Reservation;
using AutoLend.Core.Esceptions;
using AutoLend.Data.DataModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers
{
    public partial class ReservationController
    {

        /// <summary>
        /// Endpoint to create a new reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] ReservationCreateRequest reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _reservationService.CreateReservation(reservation);
                return Ok("Reservation added successfully.");
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
