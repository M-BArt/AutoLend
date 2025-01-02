using AutoLend.Domain.DataModels.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutoLend.API.Controllers.CustomerController {
    public partial class CustomerController {
        [HttpPost("customer")]
        public async Task<IActionResult> Create( [FromBody] Customer customer) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                await _customerService.Create(customer);
                return Ok("User added successfully.");
            } 
            catch (SqlException ex) {
                if (ex.Message.Contains("User already exists in the database")) {
                    return BadRequest("User already exists in the database.");
                }
                _logger.LogError(ex, "SQL error occurred: {Message}", ex.Message);
                return BadRequest(ModelState);
            }  
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
