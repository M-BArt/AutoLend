using AutoLend.Domain.DataModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update( [FromBody] Customer customer, [FromRoute] Guid customerId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _customerService.UpdateCustomer(customer);
                return Ok("Customer updated");
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
