using AutoLend.Domain.DataModels.Rental;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {
        [HttpPut("{rentalId}")]
        public async Task<IActionResult> Update( [FromBody] Rental rental, [FromRoute] int crentalId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _rentalService.UpdateRental(rental);
                return Ok("Rental updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
