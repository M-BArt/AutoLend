using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {
        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> Delete( [FromRoute] int rentalId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _rentalService.DeleteRental(rentalId);
                return Ok("Rental removed");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
