using AutoLend.Core.ApiModels.Customer;
using AutoLend.Data.DataModels.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController
{
    public partial class CustomerController
    {
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CustomerCreateRequest customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _customerService.CreateCustomer(customer);
                return Ok("Customer added successfully.");
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Customer already exists in the database."))
                {
                    return BadRequest("Customer already exists in the database.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
