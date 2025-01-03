using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CarController {
    public partial class CarController {
        [HttpGet()]
        public async Task<IActionResult> GetAll() {
            try {
                return Ok(await _carService.GetAllCars());
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
