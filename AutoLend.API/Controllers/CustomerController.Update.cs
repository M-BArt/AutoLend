using AutoLend.Core.ApiModels.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update( [FromBody] CustomerUpdateRequest customer, [FromRoute] Guid customerId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _customerService.UpdateCustomer(customerId, customer);
                return Ok("Customer updated");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Customer not found or is not active.")) {
                    return BadRequest("Customer not found or is not active.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
