using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        /// <summary>
        /// Endpoint to Delete an existing customer by their ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete( [FromRoute] Guid customerId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _customerService.DeleteCustomer(customerId);
                return Ok("Customer removed");
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