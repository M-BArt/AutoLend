using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {

        /// <summary>
        /// Endpoint to delete a car record
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpDelete("{carId}")]
        public async Task<IActionResult> Delete( [FromRoute] int carId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _carService.DeleteCar(carId);
                return Ok("Car removed");
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
