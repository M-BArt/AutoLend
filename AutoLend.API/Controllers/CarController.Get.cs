using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpGet("{carId}")]
        public async Task<IActionResult> Get( [FromRoute] int carId ) {
            try {
                return Ok(await _carService.GetCarById(carId));
            } catch (SqlException ex) {
                if (ex.Message.Contains("Car not found.")) {
                    return BadRequest("Car not found.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
