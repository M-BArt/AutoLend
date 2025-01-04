using AutoLend.Core.ApiModels.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpPost()]
        public async Task<IActionResult> Create( [FromBody] CarCreateRequest car ) {
            try {
                await _carService.CreateCar(car);
                return Ok("Car added successfully.");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Model not found.")) {
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
