using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers {
    public partial class RentalController {
        [HttpGet()]
        public async Task<IActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                return Ok(await _rentalService.GetAllRentals());
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
