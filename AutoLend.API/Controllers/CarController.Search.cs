using AutoLend.Core.ApiModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
      
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] CarSearchRequest car) {

            try { 
                return Ok(await _carService.Search(car));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest("Internal Error Server");
            }
        }
    }
}
