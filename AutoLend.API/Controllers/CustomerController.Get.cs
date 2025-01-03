using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get([FromRoute] Guid customerId ) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try {
                return Ok(await _customerService.GetCustomerById(customerId));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}