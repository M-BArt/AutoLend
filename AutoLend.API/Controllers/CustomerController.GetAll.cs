using Microsoft.AspNetCore.Mvc;

namespace AutoLend.API.Controllers.CustomerController
{
    public partial class CustomerController
    {

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _customerService.GetAllCustomers());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
