using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {

        /// <summary>
        /// Endpoint to take details of a specific rental by its ID.
        /// </summary>
        /// <param name="rentalId"></param>
        /// <returns></returns>
        [HttpGet("{rentalId}")]
        public async Task<IActionResult> Get( [FromRoute] int rentalId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _rentalService.GetRentalById(rentalId));
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
