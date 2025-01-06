using AutoLend.Core.Esceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController
{
    public partial class CustomerController
    {
        /// <summary>
        /// Endpoint to take a specific customer by their ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get([FromRoute] Guid customerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                return Ok(await _customerService.GetCustomerById(customerId));
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