using AutoLend.Domain.DataModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpGet("{carId}")]
        public async Task<IActionResult> Get( [FromRoute] int carId ) {
            try {
                return Ok(await _carService.GetCarById(carId));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
