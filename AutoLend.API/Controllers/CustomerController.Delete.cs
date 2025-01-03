using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpDelete("customer/{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try {
                await _customerService.Delete(customerId);
                return Ok("User removed");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}