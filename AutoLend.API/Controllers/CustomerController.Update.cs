using AutoLend.Core.ApiModels.Customer;
using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {

        /// <summary>
        /// Endpoint to update an existing customer's details by their ID.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update( [FromBody] CustomerUpdateRequest customer, [FromRoute] Guid customerId ) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _customerService.UpdateCustomer(customerId, customer);
                return Ok("Customer updated");
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
