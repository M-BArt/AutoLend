using AutoLend.Domain.DataModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpPost()]
        public async Task<IActionResult> Create( [FromBody] Car car ) {
            try {
                await _carService.CreateCar(car);
                return Ok("Car added successfully.");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
