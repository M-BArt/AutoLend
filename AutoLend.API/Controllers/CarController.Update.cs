using Microsoft.AspNetCore.Mvc;
using AutoLend.Domain.DataModels.Car;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpPut("{carId}")]
        public async Task<IActionResult> Update( [FromBody] Car car, [FromRoute] int carId) {
            try {
                await _carService.UpdateCar(car);
                return Ok("Car updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
