using AutoLend.Domain.DataModels.Client;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpPut("customer")]
        public async Task<IActionResult> Update( [FromBody] Customer customer ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _customerService.Update(customer);
                return Ok("User updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
