using AutoLend.Core.ApiModels.Car;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {

        /// <summary>
        /// Endpoint to Update the details of an existing car by its ID.
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut("{carId}")]
        public async Task<IActionResult> Update( [FromRoute] int carId, [FromBody] CarUpdateRequest car ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _carService.UpdateCar(carId, car);
                return Ok("Car updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);

                return ex switch {
                    BusinessException => BadRequest(ex.Message),
                    _ => StatusCode(500, "Internal Error Server")
                };
            }
        }
    }
}
