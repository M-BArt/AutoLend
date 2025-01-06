using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {

        /// <summary>
        /// Endpoint to information the details of a car by its ID.
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpGet("{carId}")]
        public async Task<IActionResult> Get( [FromRoute] int carId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _carService.GetCarById(carId));
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
