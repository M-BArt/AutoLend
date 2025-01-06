using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {

        /// <summary>
        /// Endpoint to take a list of all rentals.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _rentalService.GetAllRentals());
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
