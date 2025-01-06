using AutoLend.Core.ApiModels.Car;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {

    public partial class CarController {
        /// <summary>
        /// Endpoint to creation of a new car record.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Create( [FromBody] CarCreateRequest car ) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _carService.CreateCar(car);
                return Ok("Car added successfully.");
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
