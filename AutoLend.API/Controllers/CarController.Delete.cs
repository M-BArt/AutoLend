using AutoLend.Domain.DataModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpDelete("{carId}")]
        public async Task<IActionResult> Delete( [FromRoute] int carId ) {
            try {
                await _carService.DeleteCar( carId );
                return Ok("Car removed");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
