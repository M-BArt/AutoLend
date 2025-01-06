using AutoLend.Core.ApiModels.Car;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {

        /// <summary>
        /// Endpoint to Search for cars based on the specified search criteria.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> Search( [FromQuery] CarSearchRequest car ) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _carService.Search(car));
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
