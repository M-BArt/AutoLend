using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController
{
    public partial class CustomerController
    {
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _customerService.DeleteCustomer(customerId);
                return Ok("Customer removed");
            } catch (SqlException ex) {
                if (ex.Message.Contains("Customer not found or is not active.")) {
                    return BadRequest("Customer not found or is not active.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}