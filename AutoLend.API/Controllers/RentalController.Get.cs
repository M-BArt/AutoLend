using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {
        [HttpGet("{rentalId}")]
        public async Task<IActionResult> Get( [FromRoute] int rentalId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                return Ok(await _rentalService.GetRentalById(rentalId));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
