using AutoLend.Data.DataModels.Rental;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers
{
    public partial class RentalController
    {
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Rental rental)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _rentalService.CreateRental(rental);
                return Ok("Rental added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
