using AutoLend.Core.ApiModels.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpPut("{carId}")]
        public async Task<IActionResult> Update( [FromRoute] int carId, [FromBody] CarUpdateRequest car ) {
            try {
                await _carService.UpdateCar(carId, car);
                return Ok("Car updated");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Car not found.")) {
                    return BadRequest("Car not found.");
                } else if
                    (ex.Message.Contains("Model not found.")) {
                    return BadRequest("Model not found.");
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
