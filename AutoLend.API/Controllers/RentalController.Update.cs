using AutoLend.Core.ApiModels.Rental;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {
        /// <summary>
        /// Endpoint to update an existing rental.
        /// </summary>
        /// <param name="rentalId"></param>
        /// <param name="rental"></param>
        /// <returns></returns>
        [HttpPut("{rentalId}")]
        public async Task<IActionResult> Update( [FromRoute] int rentalId, [FromBody] RentalUpdateRequest rental) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _rentalService.UpdateRental(rentalId, rental);
                return Ok("Rental updated");
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
