using AutoLend.Core.ApiModels.Rental;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {

        /// <summary>
        /// Endpoint to create a new rental.
        /// </summary>
        /// <param name="rental"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Create( [FromBody] RentalCreateRequest rental ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _rentalService.CreateRental(rental);
                return Ok("Rental added successfully.");
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
