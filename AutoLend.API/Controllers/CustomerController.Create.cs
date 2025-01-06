using AutoLend.Core.ApiModels.Customer;
using AutoLend.Core.Esceptions;
using AutoLend.Data.DataModels.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController
{
    public partial class CustomerController
    {
        /// <summary>
        /// Endpoint to create a new customer in the system.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CustomerCreateRequest customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                await _customerService.CreateCustomer(customer);
                return Ok("Customer added successfully.");
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
